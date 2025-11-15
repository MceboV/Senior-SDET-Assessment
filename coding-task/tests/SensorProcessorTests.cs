using System;
using System.Collections.Generic;
using Xunit;
using SensorProcessor.Models;
using SensorProcessor.Services;
using SensorProcessor.Exceptions;

namespace SensorProcessor.Tests
{
    public class SensorProcessorTests
    {
        private readonly SensorProcessor _sensorProcessor;

        public SensorProcessorTests()
        {
            _sensorProcessor = new SensorProcessor();
        }

        [Fact]
        public void CalculateAveragePerDevice_ValidReadings_ReturnsCorrectAverages()
        {
            // Arrange
            var readings = new List<SensorReading>
            {
                new SensorReading("A1", DateTime.Now, 10),
                new SensorReading("A1", DateTime.Now, -5), // Should be ignored
                new SensorReading("B1", DateTime.Now, 20),
                new SensorReading("A1", DateTime.Now, 14)
            };

            // Act
            var result = _sensorProcessor.CalculateAveragePerDevice(readings);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(12, result["A1"]); // (10 + 14) / 2 = 12
            Assert.Equal(20, result["B1"]);
        }

        [Fact]
        public void CalculateAveragePerDevice_EmptyList_ThrowsEmptyReadingListException()
        {
            // Arrange
            var emptyReadings = new List<SensorReading>();

            // Act & Assert
            Assert.Throws<EmptyReadingListException>(() =>
                _sensorProcessor.CalculateAveragePerDevice(emptyReadings));
        }

        [Fact]
        public void CalculateAveragePerDevice_NullList_ThrowsEmptyReadingListException()
        {
            // Act & Assert
            Assert.Throws<EmptyReadingListException>(() =>
                _sensorProcessor.CalculateAveragePerDevice(null));
        }

        [Fact]
        public void CalculateAveragePerDevice_AllNegativeValues_ReturnsEmptyDictionary()
        {
            // Arrange
            var readings = new List<SensorReading>
            {
                new SensorReading("A1", DateTime.Now, -5),
                new SensorReading("B1", DateTime.Now, -10)
            };

            // Act
            var result = _sensorProcessor.CalculateAveragePerDevice(readings);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void CalculateAveragePerDevice_SingleDeviceMultipleReadings_CalculatesCorrectly()
        {
            // Arrange
            var readings = new List<SensorReading>
            {
                new SensorReading("A1", DateTime.Now, 5),
                new SensorReading("A1", DateTime.Now, 10),
                new SensorReading("A1", DateTime.Now, 15)
            };

            // Act
            var result = _sensorProcessor.CalculateAveragePerDevice(readings);

            // Assert
            Assert.Single(result);
            Assert.Equal(10, result["A1"]); // (5 + 10 + 15) / 3 = 10
        }
    }
}
