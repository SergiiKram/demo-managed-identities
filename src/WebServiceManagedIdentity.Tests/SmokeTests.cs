using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace WebServiceManagedIdentity.Tests
{
    public class SmokeTests
        : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public SmokeTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Ensure_runs()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("Blobs");
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.Contains("Azure.Identity.CredentialUnavailableException", responseString);
        }

        [Fact]
        public async Task Ensure_swagger_ui_runs()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("swagger/index.html");
            
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Ensure_swagger_schema_containts_controllers()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("swagger/v1/swagger.json");
            var responseString = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            Assert.Contains("/Blobs", responseString);
        }
    }
}
