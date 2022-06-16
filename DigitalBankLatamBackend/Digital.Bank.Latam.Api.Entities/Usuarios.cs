using System;

namespace Digital.Bank.Latam.Api.Entities
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Fecha_Nacimiento { get; set; }
        public string Sexo { get; set; }
        public bool State { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
