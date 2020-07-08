using System.ComponentModel.DataAnnotations;
using System;

namespace Comander.Models
{
    public class Command: Entity
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string  Plataform { get; set; }

    }
}