using App.Carros.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Carros.Domain.Entidades
{
    public class Carro
    {

        public int Id { get; protected set; }

        public string Name { get; private set; }

        public string Descricao { get; private set; }

        public string Modelo { get; private set; }

        public int Ano  { get; private set; }

        public decimal Quilometragem { get; private set; }

        public int Portas { get; private set; }

        public decimal PotenciaMotor { get; private set; }

        public string Placa { get; private set; }   

        public decimal Preco { get; private set; }

        public Carro(string name, string descricao, string modelo, int ano, decimal quilometragem, int portas, decimal potenciaMotor, string placa, decimal preco)
        {
            ValidaDomain(name,descricao,modelo,ano,quilometragem,portas,potenciaMotor,placa,preco);
        }

        public Carro(int id,string name, string descricao, string modelo, int ano, decimal quilometragem, int portas, decimal potenciaMotor, string placa, decimal preco)
        {
            DomainExceptionValidacao.When(id < 0, "Id Invalido.");
            Id = id;
            ValidaDomain(name, descricao, modelo, ano, quilometragem, portas, potenciaMotor, placa, preco);

        }

        public Carro(string name, string descricao, string modelo, int ano, decimal quilometragem, int portas, decimal potenciaMotor, string placa, 
                     decimal preco, int cambioId, int combustivelId, int marcaId, int direcaoId)
        {
            ValidaDomain(name, descricao, modelo, ano, quilometragem, portas, potenciaMotor, placa, preco);
            CambioId = cambioId;
            CombustivelId = combustivelId;
            MarcaId = marcaId;
            DirecaoId = direcaoId;

        }

        public void Update(string name, string descricao, string modelo, int ano, decimal quilometragem, int portas, decimal potenciaMotor, string placa,
                           decimal preco, int cambioId, int combustivelId, int marcaId, int direcaoId)
        {
            ValidaDomain(name, descricao, modelo, ano, quilometragem, portas, potenciaMotor, placa, preco);
            CambioId = cambioId;
            CombustivelId = combustivelId;
            MarcaId = marcaId;
            DirecaoId = direcaoId;
        }
        
        public int CambioId { get; set; }
        
        public CambioCarro Cambio { get; set; }


        public int CombustivelId { get; set; }
        
        public CombustivelCarro Combustivel { get; set; }
        

        public int MarcaId { get; set; }
        
        public MarcaCarro Marca { get; set; }


        public int DirecaoId { get; set; }
                
        public DirecaoCarro Direcao { get; set; }


        private void ValidaDomain(string name, string descricao, string modelo, int ano, decimal quilometragem, int portas, decimal potenciaMotor, string placa, decimal preco)
        {
            DomainExceptionValidacao.When(string.IsNullOrEmpty(name), "Nome Invalido. Nome é obrigatório.");
            DomainExceptionValidacao.When(string.IsNullOrEmpty(descricao), "Descrição Invalido. Descrição é obrigatório.");
            DomainExceptionValidacao.When(string.IsNullOrEmpty(modelo), "Modelo Invalido. Modelo é obrigatório.");
            DomainExceptionValidacao.When(ano < 0, "Ano Invalido.");
            DomainExceptionValidacao.When(quilometragem < 0, "Quilometragem Invalida.");
            DomainExceptionValidacao.When(portas < 0, "Quantidade de portas Invalida.");
            DomainExceptionValidacao.When(potenciaMotor < 0, "Potencia do Motor Invalida.");
            DomainExceptionValidacao.When(string.IsNullOrEmpty(placa), "Placa Invalida.");
            DomainExceptionValidacao.When(preco < 0, "Preço Invalido.");

            Name = name;
            Descricao = descricao;  
            Modelo = modelo;
            Quilometragem = quilometragem;
            Portas = portas;
            Placa = placa;
            Preco = preco;
            Ano = ano;
            PotenciaMotor = potenciaMotor;

        }


    }
}
