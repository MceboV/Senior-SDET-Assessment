using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using ApiAutomation.Utils;

namespace ApiAutomation.Tests
{
    public class NegativeAlertTests : IDisposable
    {
        private readonly ApiClient _apiClient;
        private const string BaseUrl = "https://api.example.com";

        public NegativeAlertTests()
        {
            _apiClient = new ApiClient(BaseUrl);
        }

        [Fact]
        public async Task CreateAlert_MissingDeviceId_Returns400()
        {
            // Arrange
            var invalidAlertData = TestData.CreateAlertWithoutDeviceId();

            // Act
            var response = await _apiClient.PostAsync("/alerts", invalidAlertData);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task CreateAlert_InvalidJson_Returns400()
        {
            // Arrange
            var invalidJson = "{ invalid json }";

            // Act
            var response = await _apiClient.PostAsync("/alerts", invalidJson);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        public void Dispose()
        {
            _apiClient?.Dispose();
        }
    }
}
