using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    /// <summary>
    /// Class with methods of sorting jugged array using strategy pattern
    /// </summary>
    public static class SortUtil
    {
        #region Public methods

        /// <summary>
        /// Method of sorting jugged array
        /// </summary>
        /// <param name="array">reference to jugged array</param>
        /// <param name="type">IComparer<T> type</param>
        public static void Sort(int[][] array, IComparer<int[]> compare)
        {
            Check(array);

            BubbleSort(array, compare);
        }

        /// <summary>
        /// Method of sorting jugged array
        /// </summary>
        /// <param name="array">reference to jugged array</param>
        /// <param name="compare">delegate Comparison<T> type</T></param>
        public static void Sort(int[][] array, Comparison<int[]> compare)
        {
            Check(array);

            BubbleSort(array, ComparerFactory.Create(compare));
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Method of bubble sort 
        /// </summary>
        /// <param name="array">reference to array</param>
        /// <param name="compare">IComparer<T> type</param>
        private static void BubbleSort(int[][] array, IComparer<int[]> compare)
        {
            Check(array);

            bool isSorted;
            for (int i = 0; i < array.Length; i++)
            {
                isSorted = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (compare.Compare(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        isSorted = true;
                    }
                }
                if (!isSorted)
                    break;
            }
        }

        /// <summary>
        /// Check input args 
        /// </summary>
        /// <param name="array">reference to jugged array</param>
        private static void Check(int[][] array)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentNullException(nameof(array));
        }

        /// <summary>
        /// Method for swap
        /// </summary>
        /// <param name="x">reference to the first array(row of jagged array)</param>
        /// <param name="y">reference to the second array(row of jagged array)</param>
        private static void Swap<T>(ref T x, ref T y)
        {
            var temp = x;
            x = y;
            y = temp;
        }

        /// <summary>
        /// Intermediate method of compare rows of jugged array
        /// </summary>
        /// <param name="x">reference to first array</param>
        /// <param name="y">reference to second array</param>
        /// <returns>criterion of comparison</returns>
        public static int SortBySumInc(int[] x, int[] y) => x.Sum() - y.Sum();

        /// <summary>
        /// Intermediate method of compare rows of jugged array
        /// </summary>
        /// <param name="x">reference to first array</param>
        /// <param name="y">reference to second array</param>
        /// <returns>criterion of comparison</returns>
        public static int SortBySumDec(int[] x, int[] y) => y.Sum() - x.Sum();

        /// <summary>
        /// Intermediate method of compare rows of jugged array
        /// </summary>
        /// <param name="x">reference to first array</param>
        /// <param name="y">reference to second array</param>
        /// <returns>criterion of comparison</returns>
        public static int SortByMaxInc(int[] x, int[] y) => x.Max() - y.Max();

        /// <summary>
        /// Intermediate method of compare rows of jugged array
        /// </summary>
        /// <param name="x">reference to first array</param>
        /// <param name="y">reference to second array</param>
        /// <returns>criterion of comparison</returns>
        public static int SortByMaxDec(int[] x, int[] y) => y.Max() - x.Max();

        /// <summary>
        /// Intermediate method of compare rows of jugged array
        /// </summary>
        /// <param name="x">reference to first array</param>
        /// <param name="y">reference to second array</param>
        /// <returns>criterion of comparison</returns>
        public static int SortByMinInc(int[] x, int[] y) => x.Min() - y.Min();

        /// <summary>
        /// Intermediate method of compare rows of jugged array
        /// </summary>
        /// <param name="x">reference to first array</param>
        /// <param name="y">reference to second array</param>
        /// <returns>criterion of comparison</returns>
        public static int SortByMinDec(int[] x, int[] y) => y.Min() - x.Min();
        
        #endregion
    }
}
