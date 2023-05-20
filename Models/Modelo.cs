using System;
using System.Collections.Generic;

namespace asistenteventas.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            Stocks = new HashSet<Stock>();
        }

        public string CodMod { get; set; } = null!;
        public string? DesMod { get; set; }
        public string? CodTem { get; set; }
        public short? CodFam { get; set; }
        public short? CodFam2 { get; set; }
        public short? CodPrv { get; set; }
        public short? OrdCreMod { get; set; }
        public short? CodMonVen { get; set; }
        public string? ModPreArt { get; set; }
        public string? SexMod { get; set; }
        public string? DesEshop { get; set; }
        public short? NueMod { get; set; }
        public short? SalMod { get; set; }
        public short OutMod { get; set; }
        public string? ComMod { get; set; }
        public string? LarMod { get; set; }
        public string? ManMod { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
