namespace Infrastructure.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Tries to access the element of an array in a secure manner
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="index"> Position to be accesed</param>
        /// <param name="element"> Element found (or default if it does not exists in the requested index)</param>
        /// <returns> True if index is valid and element exists or False if index is out of range or element does not exists</returns>
        public static bool TryGetElement<T>(this T[] array, int index, out T element)
        {
            if (index < array.Length && index >= 0)
            {
                element = array[index];
                return true;
            }
            element = default;
            return false;
        }
    }
}