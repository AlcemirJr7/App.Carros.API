using App.Carros.Application.DTOs;
using App.Carros.Domain.Entidades;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.Mapeamentos
{
    public class DomainToDTOMapeamentoProfile : Profile
    {
        public DomainToDTOMapeamentoProfile()
        {
            CreateMap<Carro, CarroDTO>().ReverseMap();
            CreateMap<CambioCarro, CambioCarroDTO>().ReverseMap();
            CreateMap<CombustivelCarro, CombustivelCarroDTO>().ReverseMap();
            CreateMap<DirecaoCarro, DirecaoCarroDTO>().ReverseMap();
            CreateMap<MarcaCarro, MarcaCarroDTO>().ReverseMap();
        }
    }
}
