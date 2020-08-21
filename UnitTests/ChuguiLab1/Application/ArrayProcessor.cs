using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class ArrayProcessor 
    {
        private readonly IArrayProcessorStub _arrayProcessor;
        private readonly IMock _mock;

        public ArrayProcessor(IArrayProcessorStub arrayProcessor)
        {
            _arrayProcessor = arrayProcessor;
        }

        public ArrayProcessor(IMock mock)
        {
            _mock = mock;
        }

        public double[] SortAndFilter(double[] a)
        {

            return _arrayProcessor.SortAndFilter(a);
        }

        
    }
}
