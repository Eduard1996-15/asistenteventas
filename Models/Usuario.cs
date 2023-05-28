using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace asistenteventas.Models
{
    public partial class Usuario
    {
        [Key]
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
    }
}
