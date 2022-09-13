using System;

namespace Domain.Exceptions
{
    public class OutOfRangeException : Exception
    {
        /// <summary>
        /// Exception thrown when the index used is out of range or element does not exists
        /// </summary>
        /// <param name="position"></param>
        public OutOfRangeException(int position)
            : base($"Position: {position} does not exists in the words collection")
        { }
    }
}