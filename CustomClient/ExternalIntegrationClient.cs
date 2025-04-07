using System.Text;
using System.Text.Json;
using CustomClient.Mock.Entities;
using CustomClient.Mock.Enum;
using CustomClient.Mock.Types;

namespace CustomClient;

public class ExternalIntegrationClient : IExternalIntegrationClient, IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly ISsoIntegrationParamRepository _ssoIntegrationParamRepository;
    private readonly ISsoUriRepository _ssoUriRepository;

    public ExternalIntegrationClient(ISsoUriRepository ssoUriRepository,
        ISsoIntegrationParamRepository ssoIntegrationParamRepository)
    {
        _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(20)
        };
        _ssoUriRepository = ssoUriRepository;
        _ssoIntegrationParamRepository = ssoIntegrationParamRepository;
    }

    public virtual async Task<IntegrationBalanceResponse?> GetBalanceAsync(Guid idIntegration) =>
        await GetUriResponseAsync<IntegrationBalanceResponse>(idIntegration, IntegrationUri.Balance);

    #region | Privated Methods |

    private async Task<T?> GetUriResponseAsync<T>(Guid idIntegration, IntegrationUri typeUri)
    {
        var baseUri = await GetBaseUri(idIntegration);
        var uri = await GetUri(idIntegration, typeUri);

        var joinedUri = JoinUri(baseUri, uri);

        var message = new HttpRequestMessage
        {
            RequestUri = joinedUri
        };

        var response = await _httpClient.SendAsync(message);

        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException($"Failed to get integration balance for id {idIntegration}");

        var serializedResponse = await response.Content.ReadAsStringAsync();

        T? deserializedResponse = default;

        try
        {
            await using Stream serializedResponseStream = new MemoryStream(Encoding.UTF8.GetBytes(serializedResponse));

            deserializedResponse =
                await JsonSerializer.DeserializeAsync<T>(serializedResponseStream);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return deserializedResponse;
    }

    private static Uri JoinUri(params string[] uris) => new(string.Join(',', uris));

    private async Task<string> GetUri(Guid idIntegration, IntegrationUri typeUri) =>
        (await GetUriEntity(idIntegration, typeUri)).Uri;

    private async Task<SsoUriEntity> GetUriEntity(Guid idIntegration, IntegrationUri typeUri) =>
        await _ssoUriRepository.FindUriByIntegrationAndType(idIntegration, typeUri);

    private async Task<string> GetBaseUri(Guid idIntegration) => (await GetBaseUriEntity(idIntegration)).BaseUri;

    private async Task<SsoIntegrationParamEntity> GetBaseUriEntity(Guid idIntegration) =>
        await _ssoIntegrationParamRepository.FindBaseUri(idIntegration);

    #endregion

    #region | Dispose |

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _httpClient.Dispose();
    }

    #endregion
}