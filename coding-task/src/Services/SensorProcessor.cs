using System;
using System.Collections.Generic;
using System.Linq;
using SensorProcessor.Models;
using SensorProcessor.Exceptions;

namespace SensorProcessor.Services
{
    public class SensorProcessor
    {
        public Dictionary<string, double> CalculateAveragePerDevice(List<SensorReading> readings)
        {
            if (readings == null || !readings.Any())
            {
                throw new EmptyReadingListException();
            }

            var result = readings
                .Where(reading => reading.Value >= 0) // Ignore negative values
                .GroupBy(reading => reading.DeviceId)
                .ToDictionary(
                    group => group.Key,
                    group => group.Average(reading => reading.Value)
                );

            return result;
        }
    }
}
