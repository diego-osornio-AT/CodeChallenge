using System.Collections.Generic;

namespace Application.Common.Interfaces
{
    public interface ILengthValidator
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
    }
}