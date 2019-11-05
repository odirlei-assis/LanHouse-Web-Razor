using System;
using System.Collections.Generic;

namespace Senai.LanHouse.Web.Razor.Domains
{
    public partial class TiposDefeitos
    {
        public TiposDefeitos()
        {
            RegistroDefeitos = new HashSet<RegistroDefeitos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<RegistroDefeitos> RegistroDefeitos { get; set; }
    }
}
