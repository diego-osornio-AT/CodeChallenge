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
                /*
                 * Sort Service and Validator are not injected using a DI Container since this is a simple
                 * console application, if we wanted to re-use the same functionality in different places everything
                 * is plug and play, we can easily switch console application to web api and register our services
                 * in a DI conter since our core does not depend on the Console Application
               */
                var sortService = new SortService(new Validator());
                var words = new[] { "Sonia", "Maria", "Wood", "Dempster" };
                var sortOrder = new[] { 4, 1, 3, 2 };

                Console.WriteLine("Sort Order has to start on 1");
                Console.WriteLine($"Initial words order: {string.Join(',', words)}");
                Console.WriteLine($"Initial sort order: {string.Join(',', sortOrder)}");

                var sortedWords = sortService.SortByPosition(words, sortOrder);
                Console.WriteLine($"Sorted array: {string.Join(',', sortedWords)}");
            }
            catch (NullReferenceException e)
            { Console.WriteLine(e); }
            catch (ArgumentNullException e)
            { Console.WriteLine(e); }
            catch (DuplicatedPositionException e)
            { Console.WriteLine(e); }
            catch (NonSequentialCollectionException e)
            { Console.WriteLine(e); }
            catch (WordsAndPositionsMiscountException e)
            { Console.WriteLine(e); }
        }
    }
}