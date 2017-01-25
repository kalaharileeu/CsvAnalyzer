using CsvAnalyzer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace CsvAnalyzer.Tests
{
    [TestClass()]
    public class CSVinterfaceSkiptests
    {
        [TestMethod()]
        public void TestSkipsLoadXmlLoadCsv()
        {
            //Arrange
            //The csvinterface wrap alot of the dll functionality
            CSVinterface csvinterface = new CSVinterface();
            csvinterface.InitializeXmlDataModels("Content/XMLFileSkips.xml");            //Act
            //check that data is not null
            if (csvinterface.CSVMetaAndColumndata != null)
            {
                Console.WriteLine("The datacolumns capacity is:" + csvinterface.CSVMetaAndColumndata.Count);
                csvinterface.LoadCSVdata(@"C:\testvsc\121121121121\2016y10m03d_19h28m53s_ReactivePwrMap\2016y10m03d_19h28m53s_SN121638052347_S240_60_LL_ReactivePwrMap.csv");
                //csvinterface.LoadCSVdata(@"N:\automation\HW_test_automation_data\S290_72_LL\121638052329\2016y10m11d_09h21m52s_DistAndEffBurst\2016y10m11d_09h21m52s_SN121638052329_S290_72_LL_DistAndEffBurst.csv");
                //populate the data
                //csvinterface.LoadData();
            }
            else
                Console.WriteLine("The datacolumns metadate is null!");

            if (csvinterface.CSVMetaAndColumndata.Count > 1)
            {
                var metaColumndata = csvinterface.CSVMetaAndColumndata;
                var column = metaColumndata.Find(x => "UO" == x.alias).GetFloats;
                Debug.WriteLine($"The column vcount is: {column.Count}");
                if (column.Count < 1)
                {
                    Debug.WriteLine("The column vcount is was smaller that 0");
                    Assert.Fail();
                }
                foreach (var v in csvinterface.GetColumnData("UO"))
                {
                    Debug.WriteLine(v);
                }
                return;
            }
            Assert.Fail();
        }
    }
}