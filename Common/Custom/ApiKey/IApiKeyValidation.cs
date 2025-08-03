namespace Common.Custom.ApiKey
{
    public interface IApiKeyValidation
    {
        bool IsValidApiKey(string userApiKey);
    }
}
