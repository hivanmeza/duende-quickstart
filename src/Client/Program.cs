using IdentityModel.Client;
using System.Text.Json;

var client = new HttpClient();
var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");

if (disco.IsError)
{
    Console.WriteLine(disco.Error);
    return;
}

// request token
var tokenResponse = await client.RequestClientCredentialsTokenAsync(
    new ClientCredentialsTokenRequest
    {
        Address = disco.TokenEndPoint,
        ClientId = "client",
        ClientSecret = "secret",
        Scope = "api1"
    }
);

if (tokenResponse.IsError)
{
    Console.WriteLine(tokenResponse.Error);
    return;
}

Console.WriteLine(tokenResponse.AccessToken);