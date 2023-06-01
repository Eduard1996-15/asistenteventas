using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace asistenteventas.Models
{
    public  class Vendedor
    {
        [Key]
        public int id { get; set; } 
        public string Nombre { get; set; } = null!;

        public string Contrasenia  { get; set; } = null!;



        public Vendedor()
        {
        }

        
    }
}
