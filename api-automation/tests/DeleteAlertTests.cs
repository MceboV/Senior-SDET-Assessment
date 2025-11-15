using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using ApiAutomation.Utils;

namespace ApiAutomation.Tests
{
    public class DeleteAlertTests : IDisposable
    {
        private readonly ApiClient _apiClient;
        private const string BaseUrl = "https://api.example.com";

        public DeleteAlertTests()
        {
            _apiClient = new ApiClient(BaseUrl);
        }

        [Fact]
        public async Task DeleteAlert_ExistingAlert_Returns204()
        {
            // Arrange
            var alertData = TestData.CreateValidAlert();
            var createResponse = await _apiClient.PostAsync("/alerts", alertData);
            var createContent = await createResponse.Content.ReadAsStringAsync();
            var createdAlert = JsonSerializer.Deserialize<JsonElement>(createContent);
            var alertId = createdAlert.GetProperty("id").GetString();

            // Act
            var deleteResponse = await _apiClient.DeleteAsync($"/alerts/{alertId}");

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
        }

        [Fact]
        public async Task GetAlert_AfterDeletion_Returns404()
        {
            // Arrange
            var alertData = TestData.CreateValidAlert();
            var createResponse = await _apiClient.PostAsync("/alerts", alertData);
            var createContent = await createResponse.Content.ReadAsStringAsync();
            var createdAlert = JsonSerializer.Deserialize<JsonElement>(createContent);
            var alertId = createdAlert.GetProperty("id").GetString();

            // Delete the alert
            await _apiClient.DeleteAsync($"/alerts/{alertId}");

            // Act
            var getResponse = await _apiClient.GetAsync($"/alerts/{alertId}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
        }

        public void Dispose()
        {
            _apiClient?.Dispose();
        }
    }
}
