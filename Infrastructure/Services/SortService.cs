using System;
using System.Collections.Generic;
using System.Linq;
using Application.Common.Interfaces;
using Domain.Exceptions;
using Infrastructure.Extensions;

namespace Infrastructure.Services
{
    public class SortService : ISortService
    {
        private readonly ILengthValidator lengthValidator;

        public SortService(ILengthValidator lengthValidator)
        {
            this.lengthValidator = lengthValidator ?? throw new ArgumentNullException("Length Validator is required");
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
        public IEnumerable<string> SortByPosition(string[] words, int[] positions)
        {
            if (!lengthValidator.ValidateEqualLength(words, positions))
            {
                throw new WordsAndPositionsMiscountException(words.Count(), positions.Count());
            }

            if (words is null || positions is null)
            {
                throw new NullReferenceException("Collection of words and positions are required");
            }

            var sortedWords = new List<string>();
            var positionsProcessed = new List<int>();

            for (int index = 0; index < words.Count(); index++)
            {
                var currentPosition = positions[index];
                if (positionsProcessed.Contains(currentPosition))
                {
                    throw new DuplicatedPositionException(currentPosition);
                }

                if (!words.TryGetElement(currentPosition - 1, out string word))
                {
                    throw new OutOfRangeException(currentPosition);
                }

                sortedWords.Add(word);
                positionsProcessed.Add(currentPosition);
            }

            return sortedWords;
        }
    }
}