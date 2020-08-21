using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application;
using System.IO;
using Moq;
namespace ChuguiLab1
{
    [TestClass]
    public class UnitTest1
    {
        // task 1-1
        [TestMethod]
        public void TriangleBasic()
        {
            //ARRANGE
            Triangle myTriangle = new Triangle();

            //ACT
            myTriangle.SetSides(28, 25, 15);
            double myArea = myTriangle.Area();

            //ASSERT
            Assert.AreEqual(186.77258899528056, myArea);
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TriangleNegativeSide()
        {
            //ARRANGE
            Triangle myTriangle = new Triangle();

            //ACT
            myTriangle.SetSides(-28, 25, 15);
            double myArea = myTriangle.Area();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TriangleNotTriangle()
        {
            //ARRANGE
            Triangle myTriangle = new Triangle();

            //ACT
            myTriangle.SetSides(10, 2, 3);
            double myArea = myTriangle.Area();
        }

        //task 3-2

        [TestMethod]
        public void StringFormatterTmp()
        {
            StringFormatter myStringFormatter = new StringFormatter();

            string newStr = myStringFormatter.ShortFileString(@"C:\Program\File.Tmp");

            Assert.AreEqual("FILE.TMP", newStr);
        }
        [TestMethod]
        public void StringFormatterEXE()
        {
            StringFormatter myStringFormatter = new StringFormatter();

            string newStr = myStringFormatter.ShortFileString(@"C:\Program\File.exe");

            Assert.AreEqual("FILE.TMP", newStr);
        }
        [TestMethod]
        public void StringFormatterNotEXE()
        {
            StringFormatter myStringFormatter = new StringFormatter();

            string newStr = myStringFormatter.ShortFileString(@"C:\Program\File");

            Assert.AreEqual("FILE.TMP", newStr);
        }
        [TestMethod]
        public void StringFormatterStringVoid()
        {
            StringFormatter myStringFormatter = new StringFormatter();

            string newStr = myStringFormatter.ShortFileString(@"");

            Assert.AreEqual("", newStr);
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void StringFormatterStringNull()
        {
            StringFormatter myStringFormatter = new StringFormatter();

            string newStr = myStringFormatter.ShortFileString(null);
        }

        //task3-3
        [TestMethod]
        public void ArrayProcessorCheckNegative()
        {
            ArrayProcessor myArrayprocessor = new ArrayProcessor(new MyArray());

            double[] myArray = { 2, -3, 0.1, 5.5 };
            double[] testedArray = myArrayprocessor.SortAndFilter(myArray);
            double[] expectedArray = { 2, 3, 0.1, 5.5 };

            CollectionAssert.AreEquivalent(testedArray, expectedArray);
        }
        [TestMethod]
        public void ArrayProcessorDeleteDoubleNumbers()
        {
            ArrayProcessor myArrayprocessor = new ArrayProcessor(new MyArray());

            double[] myArray = { 2, 2, 3, 3, 0.1, 0.1, 0.1, 0.1 , 5.5 };
            double[] testedArray = myArrayprocessor.SortAndFilter(myArray);
            double[] expectedArray = { 2, 3, 0.1, 5.5 };

            CollectionAssert.AreEquivalent(testedArray, expectedArray);
        }
        [TestMethod]
        public void ArrayProcessorArraySorted()
        {
            ArrayProcessor myArrayprocessor = new ArrayProcessor(new MyArray());

            double[] myArray = { 2, 3, 0.1, 5.5 };
            double[] testedArray = myArrayprocessor.SortAndFilter(myArray);
            double[] expectedArray = { 5.5, 3, 2, 0.1 };

            CollectionAssert.AreEquivalent(testedArray, expectedArray);

            Assert.AreEqual(5.5, expectedArray[0]);
            Assert.AreEqual(0.1, expectedArray[3]);
        }
        [TestMethod]
        public void ArrayProcessorAll()
        {
            ArrayProcessor myArrayprocessor = new ArrayProcessor(new MyArray());

            double[] myArray = { -2, 2, 3, 0.1, 5.5 };
            double[] testedArray = myArrayprocessor.SortAndFilter(myArray);
            double[] expectedArray = { 5.5, 3, 2, 0.1 };

            CollectionAssert.AreEquivalent(testedArray, expectedArray);

            Assert.AreEqual(5.5, expectedArray[0]);
            Assert.AreEqual(0.1, expectedArray[3]);
        }

        //lab2

        //task 1-3
        [TestMethod]
        public void SignalCheckSamplesArray()
        {
            Signal mySignal = new Signal(new MyArray());

            double[] myArray = { -2, 2, 3, 0.1, 5.5 };
            mySignal.Samples = myArray;
            mySignal.FullRectify();
            double[] expectedArray = { 5.5, 3, 2, 0.1 };

            CollectionAssert.AreEquivalent(mySignal.Samples, expectedArray);

            Assert.AreEqual(5.5, expectedArray[0]);
            Assert.AreEqual(0.1, expectedArray[3]);
        }
        [TestMethod]
        public void SignalCheckFileWriteAndRead()
        {
            Signal mySignal = new Signal(new MyArray());

            double[] myArray = { -2, 2, 3, 0.1, 5.5 };
            mySignal.Samples = myArray;
            mySignal.FullRectify();
            double[] fromFileArray = new double[3];
            double[] expectedArray = { 10.6, -10.6, 2.65 };

            string readPath = "C:\\Lab2TESTPO\\results.log";
            string[] files = Directory.GetFiles("C:\\Lab2TESTPO\\");
            int number = 1;
            for (int i = files.Length - 1; i >= 0; i--)
            {
                if (files[i].StartsWith("C:\\Lab2TESTPO\\results"))
                {
                    int indexNumber = files[i].IndexOf('(');
                    if (indexNumber == -1)
                        readPath = "C:\\Lab2TESTPO\\results.log";
                    else
                    {
                        string temp = files[i].Substring(indexNumber + 1);
                        temp = temp.Substring(0, temp.IndexOf(')'));
                        if (number <= Convert.ToInt32(temp))
                        {
                            number = Convert.ToInt32(temp);
                            readPath = $"C:\\Lab2TESTPO\\results({number}).log";
                        }
                    }
                }
            }

            StreamReader sr = new StreamReader(readPath, Encoding.Default);
            fromFileArray[0] = Convert.ToDouble(sr.ReadLine());
            fromFileArray[1] = Convert.ToDouble(sr.ReadLine());
            fromFileArray[2] = Convert.ToDouble(sr.ReadLine());
            sr.Close();

            CollectionAssert.AreEquivalent(fromFileArray, expectedArray);
        }

        [TestMethod]
        public void SignalCheckSamplesArrayStub()
        {
            Signal mySignal = new Signal(new FakeArrayProcessor());

            double[] myArray = { -2, 2, 3, 0.1, 5.5 };
            mySignal.Samples = myArray;
            mySignal.FullRectify();
            double[] expectedArray = { 3, 3, 3, 2 };

            CollectionAssert.AreEquivalent(mySignal.Samples, expectedArray);

            Assert.AreEqual(3, expectedArray[0]);
            Assert.AreEqual(2, expectedArray[3]);
        }
        [TestMethod]
        public void SignalCheckSamplesArrayMoq()
        {
            double[] array = { 3, 3, 3, 2 };
            var mock = new Mock<IArrayProcessorStub>();
            mock.Setup(d => d.SortAndFilter(It.IsAny<double[]>())).Returns(array);
            ArrayProcessor processor = new ArrayProcessor(mock.Object);
            double[] temp = processor.SortAndFilter(array);
            CollectionAssert.AreEquivalent(array, temp);
        }

        [TestMethod]
        public void SignalCheckSamplesArrayMyMock()
        {
            double[] array = { 3, 3, 3, 2 };
            var myMock = new MyMock(new FakeArrayProcessor());
            myMock.Setup(array);
            ArrayProcessor processor = new ArrayProcessor(myMock);
            var temp =myMock.Return(array);
            CollectionAssert.AreEquivalent(array, temp);

        }
            //task 2-1
            private void CreateTempFileForDelete(string dir)
        {
            if (dir.EndsWith("\\"))
            {
                dir +="temp.txt";
            }
            else
            {
                dir = dir + "\\" + "temp.txt";
            }
            StreamWriter writer = new StreamWriter(dir, false, Encoding.Default);
            writer.Write("123");
            writer.Close();
        }
        [TestMethod]
        public void FileServiceCheckBytes()
        {
            CreateTempFileForDelete("C:\\Lab2TESTPO\\");
            int deletedBytes = new FileService().RemoveTemporaryFiles("C:\\Lab2TESTPO\\");

            Assert.AreEqual(3, deletedBytes);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FileServiceDirNotFound()
        {
            new FileService().RemoveTemporaryFiles("C:\\Lab2TESTPOabc\\");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FileServiceRemoveTxtNotFound()
        {
            new FileService().RemoveTemporaryFiles("C:\\");
        }
        [TestMethod]
        public void ReportViewerCheckBytes()
        {
            CreateTempFileForDelete("C:\\Lab2TESTPO\\");
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.Clean("C:\\Lab2TESTPO\\");
            int deletedBytes = reportViewer.UsedSize;

            Assert.AreEqual(3, deletedBytes);
        }






    }
}
