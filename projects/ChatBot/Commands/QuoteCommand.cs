using ChatBot.Dtos;
using ChatBot.Repositories.Interfaces;
using ChatBot.Repositories.Models;
using Telegram.Bot;

namespace ChatBot.Commands
{
    public class QuoteCommand : IBotCommand
    {
        private readonly IChatApiClient _chatApiClient;

        public QuoteCommand(IChatApiClient chatApiClient)
        {
            _chatApiClient = chatApiClient;
        }

        public string Trigger => "/quote";

        public async Task ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId)
        {
            
            var emptyHistory = new List<OpenApiResponse.Message>();

            var prompt = "Отправь цитату, котороую я сегодня точно должен услышать.";

            try
            {
                var quote = await _chatApiClient.SendMessageAsync(prompt, emptyHistory);
                await bot.SendTextMessageAsync(chatId, $"*Цитата которую вы точно должны сегодня услышать:*\n\n{quote}", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
            }
            catch
            {
                await bot.SendTextMessageAsync(chatId, "Не удалось получить цитату");
            }
        }
    }
}
