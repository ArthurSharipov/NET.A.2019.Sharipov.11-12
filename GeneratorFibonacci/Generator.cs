using System;

namespace GeneratorFibonacci
{
    public class Generator
    {
        /// <summary>
        /// Generates Fibonacci numbers.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int[] GeneratorFibonacci(int number)
        {
            int[] array = new int[2];
            int i = 1;

            if (number >= 0)
            {
                array[0] = 0;
                array[1] = 1;

                while (i < number + 1)
                {
                    Array.Resize<int>(ref array, i + 2);
                    array[i + 1] = Positive(array[i - 1], array[i]);
                    i++;
                    if (array[i] >= int.MaxValue)
                        break;
                }
            }

            else
            {
                array[0] = 0;
                array[1] = -1;

                while (i > number + i)
                {
                    Array.Resize<int>(ref array, i + 2);
                    array[i + 1] = Negative(array[i - 1], array[i]);
                    i++;
                    number++;
                    if (array[i] >= int.MaxValue)
                        break;
                }
            }
            Array.Resize<int>(ref array, i);
            return array;
        }

        /// <summary>
        /// Method for positive numbers.
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        private int Positive(int array1, int array2) => array1 + array2;

        /// <summary>
        /// Method for negative numbers.
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        private int Negative(int array1, int array2) => array1 + array2;
    }
}