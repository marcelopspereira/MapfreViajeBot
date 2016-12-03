using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ViajeBotAPI.Dialogs
{
    [LuisModel("63747b9c-c78a-4490-a5c2-cf0155dd7d48", "7097ffa6528a4ff08b8ad3c143afb82b")]
    [Serializable]
    public class IntentionsDialog : LuisDialog<object>
    {
        private const string _intentGreeting = "Greeting";
        //private const string _intentSellIn = "SellIn";
        //private const string _intentSellOut = "SellOut";
        //private const string _intentForecast = "Forecast";
        //private const string _intentHelp = "Help";

        //private const string _entityYear = "Year";
        //private const string _entityMonth = "Month";
        //private const string _entityLocal = "Local";
        //private const string _entityProductBrand = "Product";

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = "none";
            //string message = Resources.GetNotUnderstandMessage();
            await SendOrdinaryMessage(context, message);
        }

        [LuisIntent(_intentGreeting)]
        public async Task ReplyGreeting(IDialogContext context, LuisResult result)
        {
            //var prompt = new PromptDialog() { name };

            //builder.Prompts.text(session, "What is your name?");

            PromptDialog.Confirm(
                    context,
                    AfterResetAsync,
                    "Are you sure you want to reset the count?",
                    "Didn't get that!",
                    promptStyle: PromptStyle.None);


            //string message = Resources.GetGreetingMessage();
            var message = "greeting";
            await SendOrdinaryMessage(context, message);
        }

        public async Task AfterResetAsync(IDialogContext context, IAwaitable<bool> argument)
        {
            var confirm = await argument;
            if (confirm)
            {
                //this.count = 1;
                await context.PostAsync("Reset count.");
            }
            else
            {
                await context.PostAsync("Did not reset count.");
            }
            //context.Wait(MessageReceivedAsync);
        }

        private async Task SendOrdinaryMessage(IDialogContext context, string message)
        {
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }
    }
}