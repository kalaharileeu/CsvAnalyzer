using CsvAnalyzer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace CsvAnalyzer.Tests
{
    [TestClass()]
    public class CSVinterfaceTests
    {
        [TestMethod()]
        public void CSVmetadataTest()
        {
            //Arrange
            //The csvinterface wrap alot of the dll functionality
            CSVinterface csvinterface = new CSVinterface("Content/XMLFile1.xml");
            //Act
            //check that data is not null
            if (csvinterface.CSVMetaAndColumndata != null)
            {
                Debug.WriteLine("The datacolumns capacity is:" + csvinterface.CSVMetaAndColumndata.Count);
            }
            else
                Assert.Fail();//Assert
        }

        [TestMethod()]
        public void CSVmetadataTest1()
        {
            //Arrange
            //The csvinterface wrap alot of the dll functionality
            CSVinterface csvinterface = new CSVinterface("Content/XMLFake.xml");
            //Act
            //check that data is not null
            if (csvinterface.CSVMetaAndColumndata != null)
            {
                Debug.WriteLine("The datacolumns capacity is:" + csvinterface.CSVMetaAndColumndata.Count);
                return;
            }
            else
            {
                Console.WriteLine("The datacolumns metadate is null!");
                return;
            }
            //Do not want any excaptions with this test
            //Assert.Fail();//Assert
        }

        [TestMethod()]
        public void CSVmetadataTest2()
        {
            //Arrange
            //The csvinterface wrap alot of the dll functionality
            CSVinterface csvinterface = new CSVinterface("");
            //check that data is not null
            if (csvinterface.CSVMetaAndColumndata != null)
            {
                Debug.WriteLine("The datacolumns capacity is:" + csvinterface.CSVMetaAndColumndata.Count);
                return;
            }
            else
            {
                Console.WriteLine("The datacolumns metadate is null!");
                return;
            }
            //Do not want any excaptions with this test
            //Assert.Fail();//Assert
        }

        [TestMethod()]
        public void CSVmetadataTestloadingdata()
        {
            //Arrange
            //The csvinterface wrap alot of the dll functionality
            CSVinterface csvinterface = new CSVinterface("Content/XMLFile1.xml");
            //Act
            //check that data is not null
            if (csvinterface.CSVMetaAndColumndata != null)
            {
                csvinterface.LoadCSVdata(@"C:\testvsc\121121121121\2016y10m03d_19h28m53s_ReactivePwrMap\2016y10m03d_19h28m53s_SN121638052347_S240_60_LL_ReactivePwrMap.csv");
            }
            else
                Assert.Fail();//Assert
        }

        [TestMethod()]
        public void LoadCSVdataTestloadingfalsefile4()
        {
            //Arrange
            //The csvinterface wrap alot of the dll functionality
            CSVinterface csvinterface = new CSVinterface("Content/XMLFile1.ml");
            //Act
            //check that data is not null
            //file does not exist
            csvinterface.LoadCSVdata(@"C:\121121121121\2016y10m03d_19h28m53s_ReactivePwrMap\2016y10m03d_19h28m53s_SN121638052347_S240_60_LL_ReactivePwrMap.csv");
            //even though file does not exist it should just return with no exception or fail
            Assert.Fail();//Assert
        }

        [TestMethod()]
        public void LoadCSVdataTestloadingfalsefile()
        {
            //Arrange
            //The csvinterface wrap alot of the dll functionality
            CSVinterface csvinterface = new CSVinterface("Content/XMLFile1.xml");
            //Act
            //check that data is not null
            if (csvinterface.CSVMetaAndColumndata != null)
            {
                //file does not exist
                csvinterface.LoadCSVdata(@"C:\121121121121\2016y10m03d_19h28m53s_ReactivePwrMap\2016y10m03d_19h28m53s_SN121638052347_S240_60_LL_ReactivePwrMap.csv");
                return;
            }
            //even though file does not exist it should just return with no exception or fail
            Assert.Fail();//Assert
        }
        [TestMethod()]
        public void LoadCSVdataEmptystring()
        {
            //Arrange
            //The csvinterface wrap alot of the dll functionality
            CSVinterface csvinterface = new CSVinterface("Content/XMLFile1.xml");
            //Act
            //check that data is not null
            if (csvinterface.CSVMetaAndColumndata != null)
            {
                //file does not exist
                csvinterface.LoadCSVdata("");
                return;
            }
            //even though file does not exist it should just return with no exception or fail
            Assert.Fail();//Assert
        }
        [TestMethod()]
        public void CSVmetadataTestloadingdata5()
        {
            //Arrange
            //The csvinterface wrap alot of the dll functionality
            CSVinterface csvinterface = new CSVinterface("");
            //Act
            //check that data is not null
            if (csvinterface.CSVMetaAndColumndata != null)
            {
                csvinterface.LoadCSVdata(@"C:\testvsc\121121121121\2016y10m03d_19h28m53s_ReactivePwrMap\2016y10m03d_19h28m53s_SN121638052347_S240_60_LL_ReactivePwrMap.csv");
            }
            else
                return;
            Assert.Fail();//Assert
        }

        [TestMethod()]
        public void LoadDataTest()
        {
            {
                //The csvinterface wrap alot of the dll functionality
                //CSVinterface csvinterface = new CSVinterface("Content/XMLFile1.xml");
                CSVinterface csvinterface = new CSVinterface("Content/XMLFile1.xml");
                //csvinterface.CSVmetadata("");
                //check that data is not null
                if (csvinterface.CSVMetaAndColumndata != null)
                {
                    Console.WriteLine("The datacolumns capacity is:" + csvinterface.CSVMetaAndColumndata.Count);
                    csvinterface.LoadCSVdata(@"C:\testvsc\121121121121\2016y10m03d_19h28m53s_ReactivePwrMap\2016y10m03d_19h28m53s_SN121638052347_S240_60_LL_ReactivePwrMap.csv");
                    //populate the data
                    //csvinterface.LoadData();
                    return;
                }
                else
                    Console.WriteLine("The datacolumns metadate is null!");
            }
            Assert.Fail();
        }
        [TestMethod()]
        public void LoadDataTest2()
        {
            //No csv file given, try and load data, nothing happens--good
            {
                //The csvinterface wrap alot of the dll functionality
                CSVinterface csvinterface = new CSVinterface("Content/XMLFile1.xml");
                //CSVinterface csvinterface = new CSVinterface("Content/XMLFile1.xml");
                //csvinterface.CSVmetadata("");
                //check that data is not null
                if (csvinterface.CSVMetaAndColumndata != null)
                {
                    //Console.WriteLine("The datacolumns capacity is:" + csvinterface.CSVMetaAndColumndata.Count);
                    //csvinterface.LoadCSVdata(@"C:\testvsc\121121121121\2016y10m03d_19h28m53s_ReactivePwrMap\2016y10m03d_19h28m53s_SN121638052347_S240_60_LL_ReactivePwrMap.csv");
                    //populate the data
                    //csvinterface.LoadData();
                    return;
                }
                else
                    Console.WriteLine("The datacolumns metadate is null!");
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void CSVinterfaceTestwithDatacount()
        {
            //The csvinterface wrap alot of the dll functionality
            CSVinterface csvinterface = new CSVinterface("Content/XMLFile1.xml");
            //CSVinterface csvinterface = new CSVinterface("");
            //csvinterface.CSVmetadata("");
            //check that data is not null
            if (csvinterface.CSVMetaAndColumndata != null)
            {
                Console.WriteLine("The datacolumns capacity is:" + csvinterface.CSVMetaAndColumndata.Count);
                csvinterface.LoadCSVdata(@"C:\testvsc\121121121121\2016y10m03d_19h28m53s_ReactivePwrMap\2016y10m03d_19h28m53s_SN121638052347_S240_60_LL_ReactivePwrMap.csv");
                //populate the data
                //csvinterface.LoadData();
            }
            else
                Console.WriteLine("The datacolumns metadate is null!");

            if (csvinterface.CSVMetaAndColumndata.Count > 1 )
            {
                var metaColumndata = csvinterface.CSVMetaAndColumndata;
                var column = metaColumndata.Find(x => "Wacpcu" == x.alias).GetFloats;
                Debug.WriteLine("The column vcount is: {column.count}");
                if (column.Count < 1)
                    Assert.Fail();
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void LoadCSVdataTest()
        {
            //The csvinterface wrap alot of the dll functionality
            CSVinterface csvinterface = new CSVinterface("Content/XMLFile1.xml");
            Debug.WriteLine(csvinterface.CSVMetaAndColumndata.Count);
            if (csvinterface.CSVMetaAndColumndata.Count > 1)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void LoadCSVdataTest2()
        {
            //The csvinterface wrap alot of the dll functionality
            CSVinterface csvinterface = new CSVinterface("Content/XMLFile1.xml");

            Debug.WriteLine(csvinterface.CSVMetaAndColumndata.Count);

            foreach (Column c in csvinterface.CSVMetaAndColumndata)
            {
                Debug.WriteLine(c.Columnvalues.Count);
                if(c.Columnvalues.Count > 0)Assert.Fail();
            }
        }
    }
}