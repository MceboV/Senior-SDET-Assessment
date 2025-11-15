namespace SensorProcessor.Models
{
    public class SensorReading
    {
        public string DeviceId { get; set; }
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }

        public SensorReading(string deviceId, DateTime timestamp, double value)
        {
            DeviceId = deviceId;
            Timestamp = timestamp;
            Value = value;
        }
    }
}
