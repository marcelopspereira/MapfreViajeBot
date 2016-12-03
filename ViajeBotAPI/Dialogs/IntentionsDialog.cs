using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ViajeBotAPI.Util;

namespace ViajeBotAPI.Dialogs
{
    [LuisModel("63747b9c-c78a-4490-a5c2-cf0155dd7d48", "17c77e2b1dbc48b49f135739215bf649")]
    [Serializable]
    public class IntentionsDialog : LuisDialog<object>
    {
        private const string _intentMedicoOrtopedico = "MedicoOrtopedico";
        private const string _intentMedicoGeral = "MedicoGeral";
        private const string _intentMedicoProntoSocorro = "MedicoProntoSocorro";
        private const string _intentCancelamentoVoo = "CancelamentoVoo";

        //public override async Task StartAsync(IDialogContext context)
        //{
        //    await base.StartAsync(context);

        //    //context.Wait(this.MessageReceivedAsync);
        //}


        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = ConversationResources.GetNotUnderstandMessage();
            await SendOrdinaryMessage(context, message);
        }

        [LuisIntent(_intentMedicoOrtopedico)]
        public async Task ReplyMedicoOrtopedico(IDialogContext context, LuisResult result)
        {
            context.ConversationData.SetValue("Especialidade", "Ortopedista");
            context.Call(new MedicalDialog(), ResumeAfterMedicalDialog);
        }


        [LuisIntent(_intentMedicoGeral)]
        public async Task ReplyMedicoGeral(IDialogContext context, LuisResult result)
        {
            context.ConversationData.SetValue("Especialidade", "Geral");
            context.Call(new MedicalDialog(), ResumeAfterMedicalDialog);
        }

        [LuisIntent(_intentMedicoProntoSocorro)]
        public async Task ReplyMedicoProntoSocorro(IDialogContext context, LuisResult result)
        {
            context.ConversationData.SetValue("Especialidade", "Pronto Socorro");
            context.Call(new MedicalDialog(), ResumeAfterMedicalDialog);
        }

        private async Task ResumeAfterMedicalDialog(IDialogContext context, IAwaitable<object> result)
        {
            var res = (bool) await result;

            string message;
            if (res)
            {
                message = "Já acionei o hospital e eles sabem que você deve chegar em breve!";
                await SendOrdinaryMessage(context, message);
            }
        }

        private async Task SendOrdinaryMessage(IDialogContext context, string message)
        {
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }
    }
}