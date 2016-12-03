using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViajeBotAPI.FormFlows
{
    [Serializable]
    public class PlaceInfo
    {
        [Prompt("Em que país você está?")]
        public string Country { get; set; }

        [Prompt("Em que cidade você está?")]
        public string City { get; set; }
    }
}