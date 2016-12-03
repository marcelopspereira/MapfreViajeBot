using System;
using Microsoft.Bot.Builder.FormFlow;

namespace ViajeBotAPI.FormFlows
{
    [Serializable]
    public class InitialInfo
    {
        [Prompt("Por favor digite seu CPF")]
        public string CPF { get; set; }

        [Prompt("Qual a sua Data de Nascimento?")]
        public DateTime Birthday { get; set; }
    }
}