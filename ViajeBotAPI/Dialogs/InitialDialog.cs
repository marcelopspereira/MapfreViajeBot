using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.FormFlow;
using ViajeBotAPI.FormFlows;
using ViajeBotAPI.Util;

namespace ViajeBotAPI.Dialogs
{
    [Serializable]
    public class InitialDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            var initialFormDialog = FormDialog.FromForm(this.BuildInitialForm, FormOptions.PromptInStart);
            context.Call(initialFormDialog, this.ResumeAfterInitialFormDialog);
        }

        private IForm<InitialInfo> BuildInitialForm()
        {
            return new FormBuilder<InitialInfo>()
                .AddRemainingFields()
                .Build();
        }

        private async Task ResumeAfterInitialFormDialog(IDialogContext context, IAwaitable<InitialInfo> result)
        {
            bool resultado = false;
            try
            {
                var data = await result;

                await context.PostAsync("Procurando seus dados no sistema, por favor, aguarde.");

                //Search user in database:
                var name = DatabaseUtil.GetUserName(data);
                if (string.IsNullOrEmpty(name))
                {
                    resultado = false;
                }
                else
                {
                    resultado = true;
                    //Save it on the context:
                    context.UserData.SetValue("CPF", data.CPF);
                    context.UserData.SetValue("Birthday", data.Birthday);
                    context.UserData.SetValue("Name", name);
                    await context.PostAsync($"Olá {name}, em que posso te ajudar?");
                }

                resultado = true;
            }
            catch (Exception ex)
            {
                await context.PostAsync("Um erro ocorreu durante a coleta de informações, desculpe!");
            }
            finally
            {
                context.Done(resultado);
            }
        }
    }
}