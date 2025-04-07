using CustomClient.Mock.Entities;

namespace CustomClient.Mock.Repositories;

public class SsoIntegrationParamRepository : ISsoIntegrationParamRepository
{
    public Task<SsoIntegrationParamEntity> FindBaseUri(Guid idIntegration)
    {
        throw new NotImplementedException();
    }
}