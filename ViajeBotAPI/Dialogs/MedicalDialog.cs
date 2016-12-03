using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.FormFlow;
using ViajeBotAPI.FormFlows;
using ViajeBotAPI.Util;
using ViajeBotAPI.Model;

namespace ViajeBotAPI.Dialogs
{
    [Serializable]
    public class MedicalDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("OK, Fique tranquilo! Vamos te ajudar!");

            var placeFormDialog = FormDialog.FromForm(this.BuildInitialForm, FormOptions.PromptInStart);
            context.Call(placeFormDialog, this.ResumeAfterPlaceFormDialog);
        }

        private IForm<PlaceInfo> BuildInitialForm()
        {
            return new FormBuilder<PlaceInfo>()
                .AddRemainingFields()
                .Build();
        }

        private async Task ResumeAfterPlaceFormDialog(IDialogContext context, IAwaitable<PlaceInfo> result)
        {
            bool resultado = false;
            try
            {
                var place = await result;
                var especialidade = context.ConversationData.Get<string>("Especialidade");

                await context.PostAsync($"Procurando um Hospital {especialidade} próximo a você...");

                Hospital hospitalData;
                try
                {
                    hospitalData = DatabaseUtil.GetHospitalData(place, especialidade);

                }
                catch (Exception)
                {

                    throw;
                }

                if (hospitalData == null)
                {
                    resultado = false;
                    await context.PostAsync("Infelizmente não encontramos seu registro. Tente novamente!");
                }
                else
                {
                    resultado = true;
                    //Save it on the context:
                    var name = context.UserData.Get<string>("Name");

                    await context.PostAsync($"{name}, por favor direcione-se para o Hospital {hospitalData.Name} no endereço {hospitalData.Address}!");
                }
            }
            catch (Exception ex)
            {
                await context.PostAsync("Um erro ocorreu durante a busca do hospital, desculpe!");
            }
            finally
            {
                context.Done(resultado);
            }
        }

    }
}