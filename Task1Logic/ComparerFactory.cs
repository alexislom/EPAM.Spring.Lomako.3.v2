using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    /// <summary>
    /// Class wich realize strategy pattern
    /// </summary>
    public class ComparerFactory
    {
        public static IComparer<T> Create<T>(Comparison<T> comparer)
        {
            return new DelegateComparer<T>(comparer);
        }
        private class DelegateComparer<T> : IComparer<T>
        {
            private readonly Comparison<T> comparer;

            public DelegateComparer(Comparison<T> comparer)
            {
                this.comparer = comparer;
            }
            public int Compare(T x, T y)
            {
                return this.comparer(x, y);
            }
        }
    }
}
