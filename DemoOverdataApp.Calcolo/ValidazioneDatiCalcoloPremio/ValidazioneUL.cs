using DemoOverdataApp.Shared.DTOs;
using DemoOverDataApp.Shared;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Text;

namespace DemoOverdataApp.Calcolo
{
    public class ValidazioneUL: Validazione
    {
        public PolizzaDataDTO _polizzaData { get; }
       
        public ValidazioneUL(PolizzaDataDTO polizzaData): base(polizzaData)
        {
            _polizzaData = polizzaData;
        }

        public override PolizzaDatiResponse ValidazioneAndCalcoloPremio()
        {
            if (Tipo == TipoPolizza.UL.ToString())
            {
                if (Eta < 15 || Eta > 75)
                {
                    CanProceed = false;
                }
                else if (Eta >= 15 && Eta <= 60 && Rata > 100)
                {
                    CanProceed = true;
                }
                else if (Eta > 60 && Eta <= 75 && Rata > 100 && Durata > 15)
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
