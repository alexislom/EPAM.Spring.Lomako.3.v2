using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Task1Logic;


namespace Task1Tests
{
    public class CompareMaxInc : Comparer<int[]>
    {
        public override int Compare(int[] x, int[] y)
        {
            if (x.Max() > y.Max()) return 1;
            if (x.Max() < y.Max()) return -1;
            return 0;
        }
    }

    public class CompareSumInc : Comparer<int[]>
    {
        public override int Compare(int[] x, int[] y)
        {
            if (x.Sum() > y.Sum()) return 1;
            if (x.Sum() < y.Sum()) return -1;
            return 0;
        }
    }

    [TestFixture]
    public class SortUtilTests
    {
        #region sort with delegates

        [Test]
        public void SortByMinInc_UsingDelegate_Test()
        {
            int[][] array = new int[][]{
                                            new[] { int.MinValue, int.MaxValue, 0, 2 },
                                            new[] { 0, -1, 3, 5 ,7 },
                                            new[] { 4 , 4, 8 }
                                       };

            int[][] expectedArray = new int[][] {
                                                    new int[] { int.MinValue, int.MaxValue, 0, 2 },
                                                    new int[] { 0, -1, 3, 5 ,7 },
                                                    new int[] { 4 , 4, 8 }
                                                };

            SortUtil.Sort(array, (x, y) => x.Min() - y.Min());

            CollectionAssert.AreEqual(expectedArray, array);
        }

        [Test]
        public void SortByMinDec_UsingDelegate_Test()
        {
            int[][] array = new int[][]{
                                            new[] { int.MinValue, int.MaxValue, 0, 2 },
                                            new[] { 0, -1, 3, 5 ,7 },
                                            new[] { 4 , 4, 8 }
                                       };

            int[][] expectedArray = new int[][] {
                                                    new int[] { 0, -1, 3, 5 ,7 },
                                                    new int[] { int.MinValue, int.MaxValue, 0, 2 },
                                                    new int[] { 4 , 4, 8 }
                                                };

            SortUtil.Sort(array, SortUtil.SortByMinDec);

            CollectionAssert.AreEqual(expectedArray, array);
        }

        [Test]
        public void SortBySumDec_UsingDelegate_Test()
        {
            int[][] array = new int[][]{
                                            new[] { int.MinValue, int.MaxValue, 0, 2 },
                                            new[] { 0, -1, 3, 5 ,7 },
                                            new[] { 4 , 4, 8 }
                                       };

            int[][] expectedArray = new int[][] {
                                                    new int[] { 4 , 4, 8 },
                                                    new int[] { 0, -1, 3, 5 ,7 },
                                                    new int[] { int.MinValue, int.MaxValue, 0, 2 }
                                                };

            SortUtil.Sort(array, SortUtil.SortBySumDec);

            CollectionAssert.AreEqual(expectedArray, array);
        }

        #endregion

        #region sort with interfaces

        [Test]
        public void SortByMaxInc_UsingInterface_Test()
        {
            int[][] array = new int[][]{
                                            new[] { int.MinValue, int.MaxValue, 0, 2 },
                                            new[] { 0, -1, 3, 5 ,7 },
                                            new[] { 4 , 4, 8 }
                                       };

            int[][] expectedArray = new int[][] {
                                                    new int[] { 0, -1, 3, 5 ,7 },
                                                    new int[] { 4 , 4, 8 },
                                                    new int[] { int.MinValue, int.MaxValue, 0, 2 }
                                                };

            SortUtil.Sort(array, new CompareMaxInc());

            CollectionAssert.AreEqual(expectedArray, array);
        }

        [Test]
        public void SortBySumInc_UsingInterface_Test()
        {
            int[][] array = new int[][]{
                                            new[] { int.MinValue, int.MaxValue, 0, 2 },
                                            new[] { 0, -1, 3, 5 ,7 },
                                            new[] { 4 , 4, 8 }
                                       };

            int[][] expectedArray = new int[][] {
                                                    new int[] { int.MinValue, int.MaxValue, 0, 2 },
                                                    new int[] { 0, -1, 3, 5 ,7 },
                                                    new int[] { 4 , 4, 8 }
                                                };

            SortUtil.Sort(array, new CompareSumInc());

            CollectionAssert.AreEqual(expectedArray, array);
        }

        #endregion
    }
}
