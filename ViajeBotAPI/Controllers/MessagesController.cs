﻿using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Dialogs;
using ViajeBotAPI.Dialogs;

namespace ViajeBotAPI
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            HttpResponseMessage response;

            if (activity.Type == ActivityTypes.Message)
            {
                //StateClient stateClient = activity.GetStateClient();
                //BotData userData = await stateClient.BotState.GetUserDataAsync(activity.ChannelId, activity.From.Id);
                //userData.SetProperty<bool>("SentGreeting", true);
                //await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);

                try
                {
                    await Conversation.SendAsync(activity, () => new RootDialog());


                    //await Conversation.SendAsync(activity, () => new IntentionsDialog());

                    response = Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                HandleSystemMessage(activity);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}