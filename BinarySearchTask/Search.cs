using System;

namespace BinarySearchTask
{
    public class Search
    {
        /// <summary>
        /// Binary search in a sorted array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="element"></param>
        /// <param name="comparison"></param>
        /// <returns></returns>
        public int BinarySearch<T>(T[] array, T element, Comparison<T> comparison)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if(element == null)
                throw new ArgumentNullException(nameof(element));
            if (comparison == null)
                throw new ArgumentNullException(nameof(comparison));

            int left = 0;
            int right = array.Length - 1;

            Array.Sort(array);

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                int result = comparison(element, array[middle]);

                if (result == 0)
                    return middle;

                else if (result < 0)
                    right = middle;

                else
                    left = middle + 1;
            }

            return -1;
        }
    }
}
