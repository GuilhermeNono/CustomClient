using CustomClient;
using CustomClient.Mock.Entities;
using CustomClient.Mock.Repositories;

var uriRepository = new SsoUriRepository();
var integrationParamRepository = new SsoIntegrationParamRepository();
var integrationId = Guid.NewGuid();

var clientIntegration = new ExternalIntegrationClient(uriRepository, integrationParamRepository);

var response = await clientIntegration.GetBalanceAsync(integrationId);

Console.WriteLine($"Balance: {response?.Balance}");