﻿using HusbandForAnHour.TG.States;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
namespace HusbandForAnHour.TG
{
    public class Program
    {
        //static List<long> chats = new List<long>();
        private SingleToneStorage _storage;
        static void Main(string[] args)
        {

        ITelegramBotClient client = SingleToneStorage.GetStorage().Client;
        var cts = new CancellationTokenSource();
        var cancellationToken = cts.Token;

        var receiverOptions = new ReceiverOptions()
        {
            AllowedUpdates = [UpdateType.Message, UpdateType.CallbackQuery], 
                ThrowPendingUpdates = true
        };

        client.StartReceiving
                (
                HandleUpdate,
                HandleError,
                receiverOptions,
                cancellationToken
                );
            string end = "";
            do
                end = Console.ReadLine();
            while (end != "end");

        }
    public static void HandleUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
         var users= SingleToneStorage.GetStorage().Clients;
            long id=0;
            switch (update.Type)
            {
                case UpdateType.Unknown:
                    break;
                case UpdateType.Message:
                    id = update.Message.Chat.Id;
                    if (!users.ContainsKey(id))
                        users.Add(id, new StartState());
                    if (update.Type == UpdateType.Message)
                    {
                        var message = update.Message.Text.ToLower();
                        if (message == "/admin")
                        {
                            users[id] = new AdminState();
                        }
                    }
                       
                  
                    switch (update.Message.Type)
                    {
                        case MessageType.Unknown:
                            break;
                        case MessageType.Text:
                            break;
                        case MessageType.Photo:
                            break;
                        case MessageType.Audio:
                            break;
                        case MessageType.Video:
                            break;
                        case MessageType.Voice:
                            break;
                        case MessageType.Document:
                            break;
                        case MessageType.Sticker:
                            break;
                        case MessageType.Location:
                            break;
                        case MessageType.Contact:
                            break;
                        case MessageType.Venue:
                            break;
                        case MessageType.Game:
                            break;
                        case MessageType.VideoNote:
                            break;
                        case MessageType.Invoice:
                            break;
                        case MessageType.SuccessfulPayment:
                            break;
                        case MessageType.WebsiteConnected:
                            break;
                        case MessageType.ChatMembersAdded:
                            break;
                        case MessageType.ChatMemberLeft:
                            break;
                        case MessageType.ChatTitleChanged:
                            break;
                        case MessageType.ChatPhotoChanged:
                            break;
                        case MessageType.MessagePinned:
                            break;
                        case MessageType.ChatPhotoDeleted:
                            break;
                        case MessageType.GroupCreated:
                            break;
                        case MessageType.SupergroupCreated:
                            break;
                        case MessageType.ChannelCreated:
                            break;
                        case MessageType.MigratedToSupergroup:
                            break;
                        case MessageType.MigratedFromGroup:
                            break;
                        case MessageType.Poll:
                            break;
                        case MessageType.Dice:
                            break;
                        case MessageType.MessageAutoDeleteTimerChanged:
                            break;
                        case MessageType.ProximityAlertTriggered:
                            break;
                        case MessageType.WebAppData:
                            break;
                        case MessageType.VideoChatScheduled:
                            break;
                        case MessageType.VideoChatStarted:
                            break;
                        case MessageType.VideoChatEnded:
                            break;
                        case MessageType.VideoChatParticipantsInvited:
                            break;
                        case MessageType.Animation:
                            break;
                        case MessageType.ForumTopicCreated:
                            break;
                        case MessageType.ForumTopicClosed:
                            break;
                        case MessageType.ForumTopicReopened:
                            break;
                        case MessageType.ForumTopicEdited:
                            break;
                        case MessageType.GeneralForumTopicHidden:
                            break;
                        case MessageType.GeneralForumTopicUnhidden:
                            break;
                        case MessageType.WriteAccessAllowed:
                            break;
                        case MessageType.UserShared:
                            break;
                        case MessageType.ChatShared:
                            break;
                        default:
                            break;
                    }
                    break;
                case UpdateType.InlineQuery:
                    break;
                case UpdateType.ChosenInlineResult:
                    break;
                case UpdateType.CallbackQuery:
                    id = update.CallbackQuery.Message.Chat.Id;
                    var c=users[id].ReceiveMessage(update);
                    users[id] = c;
                    break;
                case UpdateType.EditedMessage:
                    break;
                case UpdateType.ChannelPost:
                    break;
                case UpdateType.EditedChannelPost:
                    break;
                case UpdateType.ShippingQuery:
                    break;
                case UpdateType.PreCheckoutQuery:
                    break;
                case UpdateType.Poll:
                    break;
                case UpdateType.PollAnswer:
                    break;
                case UpdateType.MyChatMember:
                    break;
                case UpdateType.ChatMember:
                    break;
                case UpdateType.ChatJoinRequest:
                    break;
                default:
                    break;
            }
            users[id].SendMessage(id);

            //users[update.Message.Chat.Id].


        }
        public static void HandleError(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {

    }
}
}
