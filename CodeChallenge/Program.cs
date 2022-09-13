using System;
using Domain.Exceptions;
using Infrastructure.Services;
using Infrastructure.Validators;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var sortService = new SortService(new LengthValidator());
                var words = new[] { "Sonia", "Maria", "Wood", "Dempster" };
                var sortOrder = new[] { 4, 1, 2, 3 };

                Console.WriteLine($"Initial words order: {string.Join(',', words)}");
                Console.WriteLine($"Initial  sort order: {string.Join(',', sortOrder)}");

                var sortedWords = sortService.SortByPosition(words, sortOrder);
                Console.WriteLine($"Sorted array: {string.Join(',', sortedWords)}");
            }
            //Is this acceptable?
            catch (DuplicatedPositionException e)
            { Console.WriteLine(e); }
            catch (OutOfRangeException e)
            { Console.WriteLine(e); }
            catch (WordsAndPositionsMiscountException e)
            { Console.WriteLine(e); }
            catch (NullReferenceException e)
            { Console.WriteLine(e); }
            catch (ArgumentNullException e)
            { Console.WriteLine(e); }
        }
    }
}