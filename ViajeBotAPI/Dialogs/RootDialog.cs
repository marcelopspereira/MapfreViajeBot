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
            await context.PostAsync("Bem vindo ao Sistema Inteligente de Seguro de Viagem da MAPFRE!");
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
                    //context.Wait(MessageFromIntentionAsync);
                    context.Call(new IntentionsDialog(), ResumeAfterIntentionsDialog);

                }
                else
                {
                    context.Call(new InitialDialog(), ResumeAfterInitialDialog);
                }
            }
            catch (Exception ex)
            {
                await context.PostAsync($"Um erro ocorreu... Reiniciando o atendimento.");
                context.Wait(this.MessageReceivedAsync);
            }
        }

        public virtual async Task MessageFromIntentionAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            context.Call(new IntentionsDialog(), ResumeAfterIntentionsDialog);
            //context.Call(new InitialDialog(), ResumeAfterInitialDialog);
        }

        private async Task ResumeAfterIntentionsDialog(IDialogContext context, IAwaitable<object> result)
        {

        }
    }
}