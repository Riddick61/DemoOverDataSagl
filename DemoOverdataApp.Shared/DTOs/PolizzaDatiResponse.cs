using System;
using System.Collections.Generic;
using System.Text;

namespace DemoOverdataApp.Shared.DTOs
{
    public class DatiDiPolizza
    {
        public string TipoRata { get; set; }
        public string Eta { get; set; }
        public string Durata { get; set; }
        public string RataMensile { get; set; }
    }

    public class DatiCalcolati
    {
        public string PremioFondo1 { get; set; }
        public string PremioFondo2 { get; set; }
        public string PremioFondoGS { get; set; }
        public string PremioLordo { get; set; }
        public string PremioNetto { get; set; }
    }

    public class PolizzaDatiResponse
    {
        public bool Esito { get; set; }
        public string Errore { get; set; }
        public string MessaggioErrore { get; set; }
        public double PremioLordo { get; set; }
        public double PremioNetto { get; set; }
        public double PremioFondo1 { get; set; }
        public double PremioFondo2 { get; set; }
        public double PremioFondoGS { get; set; }
        public double Tassa { get; set; }
        public DatiDiPolizza DatiDiPolizza { get; set; }
        public DatiCalcolati DatiCalcolati { get; set; }
    }
}
