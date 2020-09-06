# DemoOverDataSagl

Chiamata con Postman =>  http://localhost:65037/api/polizza 

Nel body:

{
   "eta": "28",
   "rata":"1700",
   "tiporata": "2",
   "tipoPolizza":"UL",
   "durata":"19",
   "Fondi":[
      {
         "Fondo":"Fondo1",
         "Percentuale":30
      },
      {
         "Fondo":"Fondo2",
         "Percentuale":30
      },
      {
         "Fondo":"FondoGS",
         "Percentuale":40
      }
   ]
}


RESPONSE:

{
    "esito": false,
    "errore": null,
    "messaggioErrore": null,
    "premioLordo": 20400,
    "premioNetto": 48212,
    "premioFondo1": 9690,
    "premioFondo2": 9690,
    "premioFondoGS": 12920,
    "tassa": 4488,
    "datiDiPolizza": {
        "tipoRata": "2",
        "eta": "28",
        "durata": "19",
        "rataMensile": null
    },
    "datiCalcolati": {
        "premioFondo1": "9690",
        "premioFondo2": "9690",
        "premioFondoGS": "12920",
        "premioLordo": "20400",
        "premioNetto": "48212"
    }
}

Nel controller Polizza, al metodo SimulaPremio istanzio la classe della polizza relativa, in questo caso il tipo è UL, quindi ValutazioneUL

           // Call to Validazione and CalcolaPremio
           var validaPol = new ValidazioneUL(dataDTO);
           var response = validaPol.ValidazioneAndCalcoloPremio();
                

