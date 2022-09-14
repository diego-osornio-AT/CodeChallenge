using System;

namespace Domain.Exceptions
{
    public class WordsAndPositionsMiscountException : Exception
    {
        /// <summary>
        /// Exception thrown when the lengths of both arrays does not match
        /// </summary>
        /// <param name="wordsCount">
        /// Count of items for the words array
        /// </param>
        /// <param name="positionsCount">
        /// Count of items for the positions array
        /// </param>
        public WordsAndPositionsMiscountException(int wordsCount, int positionsCount)
            : base($"Mismatch on the number of items and number of positions found, words: {wordsCount}, positions: {positionsCount}")
        { }
    }
}