using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Carros.Application.DTOs
{
    public class CombustivelCarroDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name é obrigatório.")]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
