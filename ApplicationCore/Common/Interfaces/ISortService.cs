using System.Collections.Generic;

namespace Application.Common.Interfaces
{
    public interface ISortService
    {
        /// <summary>
        /// Sorts the string array into a new array. The new array's order will be the second array.
        /// </summary>
        /// <param name="words">
        /// Unsorted array of strings
        /// </param>
        /// <param name="positions">
        /// Represents the new order that needs to be follows by the new array created,
        /// </param>
        /// <exception cref="Domain.Exceptions.WordsAndPositionsMiscountException">
        /// Thrown when lengths from the words and positions are different
        /// </exception>
        /// <exception cref="Domain.Exceptions.OutOfRangeException">
        /// Thrown when index used to access the words array is greater or lower than the first or last position in the words array
        /// </exception>
        /// <exception cref="Domain.Exceptions.DuplicatedPositionException">
        /// Thrown when the same positions exists more than 1 in the positions parameter
        /// </exception>
        /// <exception cref="System.NullReferenceException">
        /// Thrown when either the words or positions arrays are null
        /// </exception>
        /// <returns>
        /// A new sorted array from words parameter and based on positions array
        /// </returns>
        IEnumerable<string> SortByPosition(string[] words, int[] positions);
    }
}