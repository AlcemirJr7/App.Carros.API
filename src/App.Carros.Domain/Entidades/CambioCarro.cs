using App.Carros.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Carros.Domain.Entidades
{
    public class CambioCarro
    {
        public int Id { get; protected set; }

        public string Name { get; set; }

        public CambioCarro(string name)
        {
            ValidaDomain(name);
            Name = name;
        }

        public CambioCarro(int id, string name)
        {
            DomainExceptionValidacao.When(id < 0 , "Id invalido.");
            Id = id;
            ValidaDomain(name);

        }
        public void Update(string name)
        {
            ValidaDomain(name);
        }
                
        public ICollection<Carro> Carros { get; set; }

        private void ValidaDomain(string name)
        {
            DomainExceptionValidacao.When(string.IsNullOrEmpty(name), "Nome Invalido. Nome é obrigatório.");
            Name = name;
        }


    }
}
