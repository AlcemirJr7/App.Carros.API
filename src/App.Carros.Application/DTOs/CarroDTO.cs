using App.Carros.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Carros.Application.DTOs
{
    public class CarroDTO
    {
        [JsonIgnore]
        public int Id { get;  set; }

        [Required(ErrorMessage = "Nome é obrigatorio.")]        
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get;  set; }

        [Required(ErrorMessage = "Descricao é obrigatorio.")]
        [MaxLength(200)]
        [DisplayName("Descricao")]
        public string Descricao { get;  set; }

        [Required(ErrorMessage = "Modelo é obrigatorio.")]
        [MaxLength(100)]
        [DisplayName("Modelo")]
        public string Modelo { get;  set; }

        [Required(ErrorMessage = "Ano é obrigatorio.")]
        [Range(1, 9999)]
        [DisplayName("Ano")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "Quilometragem é obrigatorio.")]                
        [DisplayName("Quilometragem")]
        public decimal Quilometragem { get; set; }

        [Required(ErrorMessage = "Portas é obrigatorio.")]
        [Range(1, 99)]
        [DisplayName("Portas")]
        public int Portas { get;  set; }

        [Required(ErrorMessage = "PotenciaMotor é obrigatorio.")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]        
        [DisplayName("PotenciaMotor")]
        public decimal PotenciaMotor { get;  set; }

        [Required(ErrorMessage = "Placa é obrigatorio.")]
        [MaxLength(50)]
        [DisplayName("Placa")]
        public string Placa { get;  set; }

        [Required(ErrorMessage = "Preco é obrigatorio.")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preco")]
        public decimal Preco { get;  set; }

        public int CambioId { get; set; }
        
        public int CombustivelId { get; set; }

        public int MarcaId { get; set; }

        public int DirecaoId { get; set; }

            
    }
}
