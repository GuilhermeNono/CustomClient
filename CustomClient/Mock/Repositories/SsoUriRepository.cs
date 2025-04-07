using CustomClient.Mock.Entities;
using CustomClient.Mock.Enum;

namespace CustomClient.Mock.Repositories;

public class SsoUriRepository : ISsoUriRepository
{
    public Task<SsoUriEntity> FindUriByIntegrationAndType(Guid idIntegration, IntegrationUri balance)
    {
        throw new NotImplementedException();
    }
}