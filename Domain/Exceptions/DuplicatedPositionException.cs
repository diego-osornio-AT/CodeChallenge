using System;

namespace Domain.Exceptions
{
    public class DuplicatedPositionException : Exception
    {
        /// <summary>
        /// Exception thrown when multiple positions are found in the sorting array
        /// </summary>
        /// <param name="position"></param>
        public DuplicatedPositionException(int position) : base($"Duplicated position found : {position}")
        { }
    }
}