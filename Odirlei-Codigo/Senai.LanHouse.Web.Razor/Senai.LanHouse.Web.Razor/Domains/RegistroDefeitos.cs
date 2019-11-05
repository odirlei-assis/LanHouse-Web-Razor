using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.LanHouse.Web.Razor.Domains
{
    public partial class RegistroDefeitos
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Informe a data")]
        [DataType(DataType.Date)]
        [Display(Name = "Data do Defeito")]
        public DateTime DataChamado { get; set; }

        [Display(Name = "Tipo do Equipamento")]
        public int? IdTipoEquipamento { get; set; }

        [Display(Name = "Tipo do Defeito")]
        public int? IdTipoDefeito { get; set; }

        [Display(Name = "Descrição do Defeito")]
        public string Descricao { get; set; }

        [Display(Name = "Tipo do Defeito")]
        public TiposDefeitos IdTipoDefeitoNavigation { get; set; }

        [Display(Name = "Tipo do Equipamento")]
        public TiposEquipamentos IdTipoEquipamentoNavigation { get; set; }
    }
}
