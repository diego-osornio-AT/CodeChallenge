using System;
using System.Collections.Generic;
using System.Linq;
using Application.Common.Interfaces;

namespace Infrastructure.Validators
{
    public class Validator : IValidator
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
        /// </returns> if it is different
        /// </returns>
        public bool ValidateEqualLength<T, U>(IEnumerable<T> collection1, IEnumerable<U> collection2)
        {
            if (collection1 is null || collection2 is null)
            {
                throw new NullReferenceException();
            }

            return collection1.Count() == collection2.Count();
        }

        /// <summary>
        /// Validates sequentiality of the collection starting at 1 as minimum value and collection.Length as maximum value
        /// </summary>
        /// <param name="collection"></param>
        /// <exception cref="System.NullReferenceException">
        /// Thrown when one or both parameters are null
        /// </exception>
        /// <returns>True when collection goes from 1 to collection.Count and false when different</returns>
        public bool ValidateConsecutiveAndIncreasingSequentiality(IEnumerable<int> collection)
        {
            if (collection is null)
            {
                throw new NullReferenceException();
            }

            return collection.Min() == 1 && collection.Max() == collection.Count();
        }

        /// <summary>
        /// Valudates that the collection does not have duplicated values
        /// </summary>
        /// <param name="collection"></param>
        /// <exception cref="System.NullReferenceException">
        /// Thrown when one or both parameters are null
        /// </exception>
        /// <returns></returns>
        public bool ValidateDuplicateValues(IEnumerable<int> collection)
        {
            if (collection is null)
            {
                throw new NullReferenceException();
            }

            return collection.Distinct().Count() == collection.Count();
        }
    }
}