using DemoOverdataApp.Shared.DTOs;
using DemoOverDataApp.Shared;
using System;
using System.Collections.Generic;

namespace DemoOverdataApp.Calcolo
{
    public class Validazione
    {
        // Request data
        public PolizzaDataDTO PolizzaData { get; }
        public string Tipo { get; set; }
        public int Eta { get; set; }
        public int Rata { get; set; }
        public int Durata { get; set; }
        public string TipoRata { get; set; }

        // Response data
        public PolizzaDatiResponse _datiResponse { get; set; } = new PolizzaDatiResponse();
        public double PremioFondo1 { get; set; } = 0;
        public double PremioFondo2 { get; set; } = 0;
        public double PremioFondoGS { get; set; } = 0;
        public double PremioLordo { get; set; } = 0;
        public double Tassa { get; set; } = 0;
        public double PremioNetto { get; set; } = 0;

        public bool CanProceed { get; set; } = false;
        public enum TipoPolizza
        {
            UL,
            TCM,
            FIP
        }

        public enum NomeFondo
        {
            Fondo1,
            Fondo2,
            FondoGS
        }

        public Validazione(PolizzaDataDTO polizzaData)
        {
            PolizzaData = polizzaData;
            Tipo = PolizzaData.TipoPolizza;
            Eta = int.Parse(PolizzaData.Eta);
            Rata = int.Parse(PolizzaData.Rata);
            Durata = int.Parse(PolizzaData.Durata);
            TipoRata = PolizzaData.TipoRata;
        }

        public Validazione()
        {
        }

        public virtual PolizzaDatiResponse ValidazioneAndCalcoloPremio()
        {
            PolizzaDatiResponse response = CalcoloPremio();
            return GetDatiPolizza(response);
        }

        public virtual PolizzaDatiResponse CalcoloPremio()
        {
            bool fondiPresenti = false;

            // -- Calcolo 
            PremioLordo = Rata * 12;
            Tassa = PolizzaData.TipoPolizza == TipoPolizza.FIP.ToString() || PolizzaData.TipoPolizza == TipoPolizza.TCM.ToString()
                ? PremioLordo * 0.27
                : PremioLordo * 0.22;

            if (PolizzaData.Fondi.Count > 0)
            {
                fondiPresenti = true;
                foreach (var fondo in PolizzaData.Fondi)
                {
                    if (fondo.Fondo == NomeFondo.Fondo1.ToString())
                    {
                        PremioFondo1 = (Rata * fondo.Percentuale / 100) * Durata;
                    }
                    else if (fondo.Fondo == NomeFondo.Fondo2.ToString())
                    {
                        PremioFondo2 = (Rata * fondo.Percentuale / 100) * Durata;
                    }
                    else if (fondo.Fondo == NomeFondo.FondoGS.ToString())
                    {
                        PremioFondoGS = (Rata * fondo.Percentuale / 100) * Durata;
                    }
                }
            }

            PremioNetto = fondiPresenti ? (PremioLordo - Tassa) + PremioFondo1 + PremioFondo2 + PremioFondoGS : PremioLordo - Tassa;

            _datiResponse.PremioFondo1 = PremioFondo1;
            _datiResponse.PremioFondo2 = PremioFondo2;
            _datiResponse.PremioFondoGS = PremioFondoGS;
            _datiResponse.PremioLordo = PremioLordo;
            _datiResponse.PremioNetto = PremioNetto;
            _datiResponse.Tassa = Tassa;

            return _datiResponse;
        }

        public virtual PolizzaDatiResponse GetDatiPolizza(PolizzaDatiResponse datiResponse)
        {
            DatiDiPolizza datiDiPolizza = new DatiDiPolizza()
            {
                Durata = Durata.ToString(),
                Eta = Eta.ToString(),
                TipoRata = TipoRata
            };

            DatiCalcolati datiCalcolati = new DatiCalcolati()
            {
                PremioFondo1 = _datiResponse.PremioFondo1.ToString(),
                PremioFondo2 = _datiResponse.PremioFondo2.ToString(),
                PremioFondoGS = _datiResponse.PremioFondoGS.ToString(),
                PremioLordo = _datiResponse.PremioLordo.ToString(),
                PremioNetto = _datiResponse.PremioNetto.ToString()
            };

            _datiResponse.DatiDiPolizza = datiDiPolizza;
            _datiResponse.DatiCalcolati = datiCalcolati;

            return _datiResponse;

        }
    }
}
