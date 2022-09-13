using System;
using System.Collections.Generic;
using System.Linq;
using Application.Common.Interfaces;
using Domain.Exceptions;

namespace Infrastructure.Services
{
    public class SortService : ISortService
    {
        private readonly IValidator validator;

        public SortService(IValidator validator)
        {
            this.validator = validator ?? throw new ArgumentNullException("Validator is required");
        }

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
        /// <exception cref="Domain.Exceptions.NonSequentialCollectionException">
        /// Thrown when positions collection is not sequential starting and 1 as minimum value and positions.Length as max value
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
        public IEnumerable<string> SortByPosition(string[] words, int[] positions)
        {
            if (words is null || positions is null)
            {
                throw new NullReferenceException("Collection of words and positions are required");
            }

            if (!validator.ValidateEqualLength(words, positions))
            {
                throw new WordsAndPositionsMiscountException(words.Count(), positions.Count());
            }

            if (!validator.ValidateDuplicateValues(positions))
            {
                throw new DuplicatedPositionException();
            }

            if (!validator.ValidateConsecutiveAndIncreasingSequentiality(positions))
            {
                throw new NonSequentialCollectionException();
            }

            return positions.Select(p => words[p - 1]);
        }
    }
}