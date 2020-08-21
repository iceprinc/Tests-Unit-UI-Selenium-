using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Application
{
    public class Signal
    {
        public double[] Samples { get; set; } = { -2, 2, 3, 0.1, 5.5 };

        private readonly IArrayProcessorStub _arrayProcessor;

        public Signal(IArrayProcessorStub arrayProcessor)
        {
            _arrayProcessor = arrayProcessor;
        }
        public void FullRectify()
        {
            
            Samples = _arrayProcessor.SortAndFilter(Samples);
            double summa = 0, raznost = 0, srednArifm = 0;
            for (int i = 0; i < Samples.Length; i++)
            {
                summa += Samples[i];
                raznost -= Samples[i];
            }
            srednArifm = summa / Samples.Length;

            if (Directory.Exists("C:\\Lab2TESTPO"))
            {

            }
            else
            {
                Directory.CreateDirectory("C:\\Lab2TESTPO");
            }
            string writePath = "C:\\Lab2TESTPO\\results.log";
            string[] files = Directory.GetFiles("C:\\Lab2TESTPO\\");
            int number = 1;
            for (int i = files.Length - 1; i >= 0; i--)
            {
                if (files[i].StartsWith("C:\\Lab2TESTPO\\results"))
                {
                    int indexNumber = files[i].IndexOf('(');
                    if (indexNumber == -1)
                        writePath = "C:\\Lab2TESTPO\\results(1).log";
                    else
                    {
                        string temp = files[i].Substring(indexNumber + 1);
                        temp = temp.Substring(0, temp.IndexOf(')'));
                        if (number <= Convert.ToInt32(temp) + 1)
                        {
                            number = Convert.ToInt32(temp) + 1;
                            writePath = $"C:\\Lab2TESTPO\\results({number}).log";
                        }
                    }
                }
            }

            StreamWriter sw = new StreamWriter(writePath, false, Encoding.Default);
            sw.WriteLine(summa);
            sw.WriteLine(raznost);
            sw.WriteLine(srednArifm);
            sw.Close();
        }
    }
}
