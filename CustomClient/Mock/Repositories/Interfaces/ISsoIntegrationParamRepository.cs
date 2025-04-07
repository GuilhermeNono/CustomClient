using CustomClient.Mock.Entities;

namespace CustomClient;

public interface ISsoIntegrationParamRepository
{
    Task<SsoIntegrationParamEntity> FindBaseUri(Guid idIntegration);
}