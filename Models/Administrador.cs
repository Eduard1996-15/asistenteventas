﻿using System;
using System.Collections.Generic;

namespace asistenteventas.Models
{
    public partial class Administrador
    {
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;

        public virtual Usuario CodigoNavigation { get; set; } = null!;
    }
}