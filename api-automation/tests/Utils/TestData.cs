using System;
using System.Text.Json;

namespace ApiAutomation.Utils
{
    public static class TestData
    {
        public static object CreateValidAlert()
        {
            return new
            {
                deviceId = Guid.NewGuid().ToString(),
                timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                value = 25.5,
                alertType = "HIGH_TEMPERATURE",
                severity = "HIGH"
            };
        }

        public static object CreateAlertWithoutDeviceId()
        {
            return new
            {
                timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                value = 25.5,
                alertType = "HIGH_TEMPERATURE"
            };
        }
    }
}
