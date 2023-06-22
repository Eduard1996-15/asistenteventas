using System;
using System.Collections.Generic;

namespace asistenteventas.Models
{
    public partial class Stock
    {
        public Stock()
        {
            Facloc1s = new HashSet<Facloc1>();
        }

        public string CodArt { get; set; } = null!;
        public string? DesArt { get; set; }
        public string? DesDetArt { get; set; }
        public string? CodMod { get; set; }
        public string? CodColPrv { get; set; }
        public string? CodTalPrv { get; set; }
        public string? CodArtAlt { get; set; }
        public int SalWebArt { get; set; }
        public byte[] Imagen { get; set; }

        public virtual Modelo? CodModNavigation { get; set; }
        public virtual ICollection<Facloc1> Facloc1s { get; set; }
    }
}
