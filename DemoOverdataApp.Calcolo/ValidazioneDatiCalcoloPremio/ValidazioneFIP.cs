using DemoOverdataApp.Shared.DTOs;
using DemoOverDataApp.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoOverdataApp.Calcolo
{
    public class ValidazioneFIP : Validazione
    {
        public PolizzaDataDTO _polizzaData { get; }
        public ValidazioneFIP(PolizzaDataDTO polizzaData) : base(polizzaData)
        {
            _polizzaData = polizzaData;
        }

        public override PolizzaDatiResponse ValidazioneAndCalcoloPremio()
        {
            if (Tipo == TipoPolizza.FIP.ToString())
            {
                if (Eta < 18)
                {
                    CanProceed = false;
                }
                else if (Eta >= 18 && Eta <= 62 && Rata >= 600 && Rata <= 2500 && Durata >= 5 && Durata <= 35)
                {
                    CanProceed = true;
                }
                else if (Eta > 62 && Rata > 1550 && Durata >= 5 && Durata <= 7)
                {
                    CanProceed = true;
                }
            }

            if (CanProceed)
            {
                PolizzaDatiResponse response = CalcoloPremio();
                PolizzaDatiResponse responseString = GetDatiPolizza(response);
                return responseString;
            }
            
            return null;

        }

    }
}
