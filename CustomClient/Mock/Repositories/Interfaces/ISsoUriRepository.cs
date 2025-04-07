using CustomClient.Mock.Entities;
using CustomClient.Mock.Enum;

namespace CustomClient;

public interface ISsoUriRepository
{
    Task<SsoUriEntity> FindUriByIntegrationAndType(Guid idIntegration, IntegrationUri balance);
}