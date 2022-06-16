using System;
using System.ComponentModel.DataAnnotations;

namespace Digital.Bank.latam.Api.Data.Transfer.Object
{
    public class UsuariosDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string Fecha_Nacimiento { get; set; }

        [Required]
        public string Sexo { get; set; }

        public bool State { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
