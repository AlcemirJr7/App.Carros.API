using App.Carros.Application.Interfaces;
using App.Carros.Application.Mapeamentos;
using App.Carros.Application.Servicos;
using App.Carros.Domain.Interfaces;
using App.Carros.Infra.Data.Contexto;
using App.Carros.Infra.Data.Repositorio;
using CleanArchMvc.Domain.Account;
using CleanArchMvc.Infra.Data.Indentity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace App.Carros.Infra.IoC
{
    public static class InjecaoDependencia
    {        
        public static IServiceCollection AddInfraestrutura(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<AppDbContexto>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(AppDbContexto).Assembly.FullName)));

            services.AddIdentity<AppUser, IdentityRole>()
                     .AddEntityFrameworkStores<AppDbContexto>().AddDefaultTokenProviders();
            
            
            //Rrepositorios           
            services.AddScoped<ICarroRepositorio, CarroRepositorio>();
            services.AddScoped<ICambioCarroRepositorio, CambioCarroRepositorio>();
            services.AddScoped<ICombustivelCarroRepositorio, CombustivelCarroRepositorio>();
            services.AddScoped<IDirecaoCarroRepositorio, DirecaoCarroRepositorio>();
            services.AddScoped<IMarcaCarroRepositorio, MarcaCarroRepositorio>();

            //serviços
            services.AddScoped<ICarroService, CarroService>();
            services.AddScoped<ICambioCarroService, CambioCarroService>();
            services.AddScoped<IMarcaCarroService, MarcaCarroService>();
            services.AddScoped<ICombustivelCarroService, CombustivelCarroService>();
            services.AddScoped<IDirecaoCarroService, DirecaoCarroService>();

            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            services.AddScoped<IAuthenticate, AuthenticateService>();
            

            services.AddAutoMapper(typeof(DomainToDTOMapeamentoProfile));
                                    
            var myHandlers = AppDomain.CurrentDomain.Load("App.Carros.Application");
            services.AddMediatR(myHandlers);            
            
            return services;
        }



        

      
    }
}
