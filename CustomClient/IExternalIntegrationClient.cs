using CustomClient.Mock.Types;

namespace CustomClient;

public interface IExternalIntegrationClient
{
    Task<IntegrationBalanceResponse?> GetBalanceAsync(Guid idIntegration);
}