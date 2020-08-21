using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class MyMock: IMock
    {

        private double[] _tempMass;
        public double[] TempMass { private set => _tempMass = value; get => _tempMass; }
        private readonly IArrayProcessorStub _arrayProcessor;


        public MyMock(IArrayProcessorStub arrayProcessor)
        {
            _arrayProcessor = arrayProcessor;
        }

        public void Setup(double[] mass)
        {
            _tempMass = mass;
        }
        
        public double[] Return(double[] mass)
        {
            return _arrayProcessor.SortAndFilter(mass);
        }



    }
}
