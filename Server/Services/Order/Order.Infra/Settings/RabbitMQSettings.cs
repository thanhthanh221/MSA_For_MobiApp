namespace Order.Infra.Settings
{
    public class RabbitMQSettings
    {
        public string Host { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public string Virtual_host { get; init; }
    }
}
