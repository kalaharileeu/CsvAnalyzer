using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsvAnalyzer.Tests
{
    [TestClass()]
    public class XmlManagerTests
    {
        [TestMethod()]
        public void LoadTest()
        {
            DataColumns datacolumns;       
            XmlManager<DataColumns> columnloader = new XmlManager<DataColumns>();
            //Initialize the datacolumns class with the wanted columns
            //XML file build action none, Copy if newer
            datacolumns = columnloader.Load("Content/XMLFile1.xml");
            if (datacolumns != null)
            {
                if (datacolumns.namealiaslist.Count < 1)
                    Assert.Fail();
            }
            else
                Assert.Fail("data columns null");
        }
    }
}