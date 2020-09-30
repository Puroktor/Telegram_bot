using System;
using System.Threading;

namespace Starter
{
    class Program
    {
        static void Main(string[] args)
        {
            DoWork();
            Console.ReadLine();
        }

       static async void DoWork()
        {
            var Bot = new Telegram.Bot.TelegramBotClient("412328897:AAFFYLJ8W1JjRrY5oQk3dwlNE_O4qLynZhA");
            await Bot.SetWebhookAsync("");

            Bot.OnUpdate += async (object su, Telegram.Bot.Args.UpdateEventArgs evu) =>
            {
                if (evu.Update.CallbackQuery != null || evu.Update.InlineQuery != null) return;
                var update = evu.Update;
                var message = update.Message;
                if (message == null) return;
                if (message.Type == Telegram.Bot.Types.Enums.MessageType.TextMessage)
                {
                    if (message.Text.ToLower() == "/start")
                    {
                        await Bot.SendTextMessageAsync(message.Chat.Id, "Здравствуйте, что вам от меня надо?",Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, Keyboard());
                    }
                }
            };

            Bot.OnCallbackQuery += async (object sc, Telegram.Bot.Args.CallbackQueryEventArgs ev) =>
            {
                var message = ev.CallbackQuery.Message;
                if (ev.CallbackQuery.Data == "a")
                {
                    await Bot.SendTextMessageAsync(message.Chat.Id, @"@dvachannel
@mudak
@ftp_dank_memes
@LaQeque
@ruOvsyanochan
@mudaks
                               ");
                }
                else

                if (ev.CallbackQuery.Data == "r")
                {
                    await Bot.SendContactAsync(message.Chat.Id, "+79601206458", "Ostap", "Kit");
                }
                else
                if (ev.CallbackQuery.Data == "b")
                {
                    await Bot.SendTextMessageAsync(message.Chat.Id, "@meduzalive");
                }
                else
                if (ev.CallbackQuery.Data == "d")
                {
                    await Bot.SendTextMessageAsync(message.Chat.Id, "@sticker");
                }

                string[] represent = { "Мож ещё чего?", "Ещё чего надо?", "Что-нибудь ещё?", "Ещё что-нибудь?", "Что то ещё?", "Мож ещё чего ?" };

                await Bot.SendTextMessageAsync(message.Chat.Id, represent[new Random().Next(0, 6)], Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, Keyboard());
            };

            Bot.StartReceiving();
        }

        static Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup Keyboard()
        {
            var keyboard = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(
                                                     new Telegram.Bot.Types.InlineKeyboardButtons.InlineKeyboardCallbackButton[][]
                                                     {
                                                            new [] {

                                                                new Telegram.Bot.Types.InlineKeyboardButtons.InlineKeyboardCallbackButton("Мемов!","a"),
                                                            },
                                                            new[]
                                                            {
                                                                new Telegram.Bot.Types.InlineKeyboardButtons.InlineKeyboardCallbackButton("Стикеров!","d")
                                                            },
                                                            new[]
                                                            {
                                                                new Telegram.Bot.Types.InlineKeyboardButtons.InlineKeyboardCallbackButton("Норм СМИ!","b"),
                                                            },
                                                            new[]
                                                            {
                                                                new Telegram.Bot.Types.InlineKeyboardButtons.InlineKeyboardCallbackButton("Контакты создателя!","r")
                                                            }
                                                     }
                                                 );
            return keyboard;
        }
    }
}

 
