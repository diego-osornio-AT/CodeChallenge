using System;

namespace Domain.Exceptions
{
    public class NonSequentialCollectionException : Exception
    {
        /// <summary>
        /// Thrown when collection is non sequential and not starting at 1 with max value of collection.Length
        /// </summary>
        public NonSequentialCollectionException() : base("Collection is not sequential starting on 1")
        {
        }
    }
}