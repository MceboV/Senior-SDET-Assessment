using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using ApiAutomation.Utils;

namespace ApiAutomation.Tests
{
    public class CreateAlertTests : IDisposable
    {
        private readonly ApiClient _apiClient;
        private const string BaseUrl = "https://api.example.com";

        public CreateAlertTests()
        {
            _apiClient = new ApiClient(BaseUrl);
        }

        [Fact]
        public async Task CreateAlert_ValidData_Returns201AndResponse()
        {
            // Arrange
            var alertData = TestData.CreateValidAlert();

            // Act
            var response = await _apiClient.PostAsync("/alerts", alertData);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<JsonElement>(responseContent);

            Assert.True(responseObject.TryGetProperty("id", out _));
            Assert.True(responseObject.TryGetProperty("deviceId", out var deviceId));
            Assert.Equal(((JsonElement)alertData).GetProperty("deviceId").GetString(), deviceId.GetString());
        }

        public void Dispose()
        {
            _apiClient?.Dispose();
        }
    }
}
