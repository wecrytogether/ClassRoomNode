using Auth0Identity.Providers;
using Auth0Identity.Settings;
using Microsoft.Extensions.Options;
using Moq;
using Xunit.Abstractions;

namespace TestProject1;

public class UnitTest1
{
    private readonly ITestOutputHelper _testOutputHelper;

    public UnitTest1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async Task Test1()
    {
        var mock = new Mock<IOptions<Auth0TenantSettings>>();
        mock
            .Setup(x => x.Value)
            .Returns(new Auth0TenantSettings
            {
                Url = "https://dev-wecrytogether.us.auth0.com/",
                ClientId = "BMEtLjnmLaAezRXqqIcytpaO9BA8ex94",
                ClientSecret = "qT1dDXfebAenPzpMrND1oau_wLHomK8XHXXR1gwX0QZWmzg1t7QR7xU5xNOvhNrM",
                Audience = "http://localhost:5221",
                GrantType = "client_credentials"
            });
        var x = new ManagementApiCredentialSingleton(mock.Object);

        await x.RefreshAccessTokenAsync();
        
        _testOutputHelper.WriteLine(x.AccessToken);
    }
}