using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class MyArray : IArrayProcessorStub

    {
        public double[] SortAndFilter(double[] array)
        {
            double[] newa = array;
            for (int i = 0; i < newa.Length; i++)
            {
                if (newa[i] < 0)
                {
                    newa[i] *= -1;
                }
            }
            Array.Sort(newa);
            Array.Reverse(newa);
            newa = newa.Distinct().ToArray();
            return newa;
        }
    }
}
