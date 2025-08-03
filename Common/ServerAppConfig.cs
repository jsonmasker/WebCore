namespace Common
{
    public class ServerAppConfig
    {
        //QRCode Server
        public required string PythonServiceUrl { get; set; }
        //Server
        public required string ServerUrl { get; set; }
        //Client
        public required string ClientUrl { get; set; }
        public required string WebhookEndpointUrl { get; set; }
        //mongodb
        public required string MongoConnectionString { get; set; }
        public required string MongoDatabaseName { get; set; }
        public required string LogUserActionCollection { get; set; }
        //JWT
        public required string Key { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public int ExpiredTime { get; set; }

        //Email
        public string? DisplayName { get; set; }
        public string? From { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Host { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }
        public bool UseStartTls { get; set; }
    }
}
