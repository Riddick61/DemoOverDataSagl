using DemoOverdataApp.Shared.DTOs;
using DemoOverDataApp.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoOverdataApp.Calcolo
{
    public class ValidazioneTCM : Validazione
    {
        public PolizzaDataDTO _polizzaData { get; }
        public ValidazioneTCM(PolizzaDataDTO polizzaData): base(polizzaData)
        {
            _polizzaData = polizzaData;
        }

        public override PolizzaDatiResponse ValidazioneAndCalcoloPremio()
        {
            if (Tipo == TipoPolizza.TCM.ToString())
            {
                if (Eta < 20 || Eta > 60)
                {
                    CanProceed = false;
                }
                else if (Eta >= 20 && Eta <= 50 && Rata >= 1500 && Rata <= 2000 && Durata > 18)
                {
                    CanProceed = true;
                }
                else if (Eta > 50 && Eta <= 60 && Eta > 24 && Rata > 1750)
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
