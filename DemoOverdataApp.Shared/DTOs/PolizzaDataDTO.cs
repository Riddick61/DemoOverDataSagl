using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoOverDataApp.Shared
{
    public class Fondi
    {
        public string Fondo { get; set; }
        public int Percentuale { get; set; }
    }

    public class PolizzaDataDTO
    {
        [Required]
        public string Eta { get; set; }
        [Required]
        public string Rata { get; set; }
        [Required]
        public string TipoPolizza { get; set; }
        [Required]
        public string Durata { get; set; }
        public string TipoRata { get; set; }
        public List<Fondi> Fondi { get; set; }
    }
}
