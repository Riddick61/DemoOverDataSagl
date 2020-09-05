namespace DemoOverDataApp.Models
{
    public class Polizza
    {
        public string TipoPolizza { get; set; }
        public int TipoRata { get; set; }
        public int Età { get; set; }
        public int Durata { get; set; }
        public double RataMensile { get; set; }
        public double PremioLordo { get; set; }
        public double PercentualeAllocazioneFondo1 { get; set; }
        public double PercentualeAllocazioneFondo2 { get; set; }
        public double PercentualeAllocazioneFondoGS { get; set; }
        public double PremioFondo1 { get; set; }
        public double PremioFondo2 { get; set; }
        public double PremioFondoGS { get; set; }
        public double Tasse { get; set; }
        public double PremioNetto { get; set; }
    }
}
