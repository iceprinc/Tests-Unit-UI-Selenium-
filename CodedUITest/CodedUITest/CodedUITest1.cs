using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CodedUITest
{
    /// <summary>
    /// Сводное описание для CodedUITest1 
    /// </summary>
    /// Работает на Visual Studio - enterprise !
    [CodedUITest]
    public class CodedUITest1
    {
        [TestMethod]
        public void CodedUITestMethod1()
        {
            // сначала открыть окно приложения (напр. Ctrl + F5), затем запускать тест
            this.UIMap.ПолныйТестПрограммыСРабСтола();
        }

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
