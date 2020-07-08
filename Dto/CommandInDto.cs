using System;
using System.ComponentModel.DataAnnotations;

namespace Comander.Dto
{
    public class CommandInDto
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Plataform { get; set; }
    }
}