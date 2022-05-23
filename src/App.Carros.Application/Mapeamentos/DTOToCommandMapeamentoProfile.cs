using App.Carros.Application.CambioCarros.Commands;
using App.Carros.Application.Carros.Handlers;
using App.Carros.Application.CombustivelCarros.Commands;
using App.Carros.Application.DirecaoCarros.Commands;
using App.Carros.Application.DTOs;
using App.Carros.Application.MarcaCarros.Commands;
using AutoMapper;


namespace App.Carros.Application.Mapeamentos
{
    public class DTOToCommandMapeamentoProfile : Profile
    {
        public DTOToCommandMapeamentoProfile()
        {
            
            CreateMap<CarroDTO, CarroCriarCommand>();
            CreateMap<CarroDTO, CarroAlterarCommand>();
            

            CreateMap<CambioCarroDTO, CambioCarroCriarCommand>();
            CreateMap<CambioCarroDTO, CambioCarroAlterarCommand>();
            

            CreateMap<CombustivelCarroDTO, CombustivelCarroCriarCammand>();
            CreateMap<CombustivelCarroDTO, CombustivelCarroAlterarCammand>();
            

            CreateMap<DirecaoCarroDTO, DirecaoCarroCriarCommand>();
            CreateMap<DirecaoCarroDTO, DirecaoCarroAlterarCommand>();
            

            CreateMap<MarcaCarroDTO, MarcaCarroCriarCommand>();
            CreateMap<MarcaCarroDTO, MarcaCarroAlterarCommand>();
            



        }
    }
}
