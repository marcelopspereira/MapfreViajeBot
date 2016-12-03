using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViajeBotAPI.Util
{
    public class ConversationResources
    {
        private static List<string> _notUnderstandList = new List<string>()
        {
            "Não entendi! Desculpe!",
            "Pode falar de outra maneira, por favor?",
            "Anh?",
            "Não entendi! Estou em treinamento ainda.. Vou melhorar em breve!"
        };

        public static string GetNotUnderstandMessage()
        {
            var random = new Random().Next(0, _notUnderstandList.Count - 1);
            return _notUnderstandList[random];
        }
    }
}