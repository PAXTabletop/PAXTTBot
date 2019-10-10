// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace Microsoft.BotBuilderSamples.Bots
{
    public class PAXTTBot : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            string message = turnContext.Activity.Text;
            string matchMessage = message.ToLower();
            ChannelAccount sender = turnContext.Activity.From;

            if (matchMessage.Contains("say hello")) {
                await turnContext.SendActivityAsync(MessageFactory.Text("Hello, my name is PAXTTBot!"), cancellationToken);
            } else {
                await turnContext.SendActivityAsync(MessageFactory.Text($"Echo: <{message}> , from: {sender.Name + ' ' + sender.Id + ' ' + sender.Properties}"), cancellationToken);
            }
        }
    }
}
