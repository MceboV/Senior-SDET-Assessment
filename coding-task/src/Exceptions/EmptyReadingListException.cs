using System;

namespace SensorProcessor.Exceptions
{
    public class EmptyReadingListException : Exception
    {
        public EmptyReadingListException()
            : base("Sensor readings list cannot be empty")
        {
        }

        public EmptyReadingListException(string message)
            : base(message)
        {
        }
    }
}
