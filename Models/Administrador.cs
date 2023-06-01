using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
namespace asistenteventas.Models
{
    public partial class Administrador
    {

        [Key]
        public int id { get; set; }
        public string Nombre { get; set; } = null!;

        public string Contrasenia { get; set; } = null!;



        public Administrador()
        {
        }

        
    }
}
