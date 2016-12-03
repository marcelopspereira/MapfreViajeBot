using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using ViajeBotAPI.FormFlows;

namespace ViajeBotAPI.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Bem vindo ao Sistema Inteligente de Sinistros da MAPFRE!");
            context.Wait(this.MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            context.Call(new InitialDialog(), ResumeAfterInitialDialog);
        }

        private async Task ResumeAfterInitialDialog(IDialogContext context, IAwaitable<object> result)
        {
            try
            {
                var success = (bool) await result;

                if (success)
                {
                    context.Call(new IntentionsDialog(), ResumeAfterIntentionsDialog);
                }
                else
                {
                    context.Wait(this.MessageReceivedAsync);
                }
            }
            catch (Exception ex)
            {
                await context.PostAsync($"Um erro ocorreu... Reiniciando o atendimento.");
                context.Wait(this.MessageReceivedAsync);
            }
        }

        private async Task ResumeAfterIntentionsDialog(IDialogContext context, IAwaitable<object> result)
        {

        }
    }
}