namespace Common.Models
{
    public class UserActionLoggingDatabaseSettings
    {
        public required string ConnectionString { get; set; }

        public required string DatabaseName { get; set; }

        public required string UserActionsCollectionName { get; set; }
    }
}
