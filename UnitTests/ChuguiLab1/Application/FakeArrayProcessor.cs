using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
   public class FakeArrayProcessor: IArrayProcessorStub
    {
        public double[] SortAndFilter(double[] a)
        {
            double[] mass = { 3, 3, 3, 2 };
            return mass;
        }
    }
}
