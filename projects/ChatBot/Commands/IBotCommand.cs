using ChatBot.Dtos;
using Telegram.Bot;

public interface IBotCommand
{
    string Trigger { get; }
    Task ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId);

}

