namespace ChatBot.Settings
{
    public class ChatApiSettings
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string ApiKey { get; } = string.Empty;
        public string DefaultModel { get; } = "openrouter/hunter-alpha";

    }
}
