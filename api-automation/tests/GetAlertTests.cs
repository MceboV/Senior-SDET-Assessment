using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using ApiAutomation.Utils;

namespace ApiAutomation.Tests
{
    public class GetAlertTests : IDisposable
    {
        private readonly ApiClient _apiClient;
        private const string BaseUrl = "https://api.example.com";

        public GetAlertTests()
        {
            _apiClient = new ApiClient(BaseUrl);
        }

        [Fact]
        public async Task GetAlert_ExistingAlert_Returns200AndCorrectData()
        {
            // Arrange - First create an alert
            var alertData = TestData.CreateValidAlert();
            var createResponse = await _apiClient.PostAsync("/alerts", alertData);
            var createContent = await createResponse.Content.ReadAsStringAsync();
            var createdAlert = JsonSerializer.Deserialize<JsonElement>(createContent);
            var alertId = createdAlert.GetProperty("id").GetString();

            // Act
            var getResponse = await _apiClient.GetAsync($"/alerts/{alertId}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

            var getContent = await getResponse.Content.ReadAsStringAsync();
            var retrievedAlert = JsonSerializer.Deserialize<JsonElement>(getContent);

            Assert.Equal(alertId, retrievedAlert.GetProperty("id").GetString());
        }

        [Fact]
        public async Task GetAlert_NonExistentAlert_Returns404()
        {
            // Arrange
            var nonExistentId = Guid.NewGuid().ToString();

            // Act
            var response = await _apiClient.GetAsync($"/alerts/{nonExistentId}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        public void Dispose()
        {
            _apiClient?.Dispose();
        }
    }
}
