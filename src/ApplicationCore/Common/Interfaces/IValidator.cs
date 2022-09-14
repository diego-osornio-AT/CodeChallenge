using System.Collections.Generic;

namespace Application.Common.Interfaces
{
    public interface IValidator
    {
        /// <summary>
        /// Validates two collections to have the same length
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="collection1">
        /// First Collection
        /// </param>
        /// <param name="collection2">
        /// Second Collection
        /// </param>
        /// <exception cref="System.NullReferenceException">
        /// Thrown when one or both parameters are null
        /// </exception>
        /// <returns>
        /// True if length is equal or False if it is different
        /// </returns>
        bool ValidateEqualLength<T, U>(IEnumerable<T> collection1, IEnumerable<U> collection2);

        /// <summary>
        /// Validates sequentiality of the collection starting at 1 as minimum value and collection.Length as maximum value
        /// </summary>
        /// <param name="collection"></param>
        /// <exception cref="System.NullReferenceException">
        /// Thrown when one or both parameters are null
        /// </exception>
        /// <returns>True when collection goes from 1 to collection.Count and false when different</returns>
        bool ValidateConsecutiveAndIncreasingSequentiality(IEnumerable<int> collection);

        /// <summary>
        /// Valudates that the collection does not have duplicated values
        /// </summary>
        /// <param name="collection"></param>
        /// <exception cref="System.NullReferenceException">
        /// Thrown when one or both parameters are null
        /// </exception>
        /// <returns></returns>
        bool ValidateDuplicateValues(IEnumerable<int> collection);
    }
}