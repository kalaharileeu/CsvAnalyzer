using System;
using CsvAnalyzer;

namespace TestDrivecsvAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            //The csvinterface wrap alot of the dll functionality
            CSVinterface csvinterface = new CSVinterface();
            csvinterface.InitializeXmlDataModels("Content/XMLFile1.xml");
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

            foreach (Column c in csvinterface.CSVMetaAndColumndata)
            {
                //only add pcu values for plotting but not if is contains "NOFF" && "imag"
                if (c.alias.Contains("pcu") && !(c.alias.Contains("NOFF")) && !(c.alias.Contains("Iacimag")))
                {
                    Console.WriteLine(c.alias);
                }
            }

            if (csvinterface.CSVMetaAndColumndata.Count > 1)
            {
                var metaColumndata = csvinterface.CSVMetaAndColumndata;
                var column = metaColumndata.Find(x => "Wacpcu" == x.alias).GetFloats;
                Console.WriteLine($"The column vcount is: {column.Count}");
                if (column.Count < 1)
                    Console.WriteLine("FAIL!");
            }

            if (csvinterface.GetColumnData("SerialNumber").Count == 0)
            {
                //WriteLine("NULL from testrun load");
                Console.WriteLine("Serial number is there");
            }

            CSVinterface csvinterface_SKIPS = new CSVinterface();
            csvinterface_SKIPS.InitializeXmlDataModels("Content/XMLFileSkips.xml");
            //CSVinterface csvinterface = new CSVinterface("");
            //csvinterface.CSVmetadata("");
            //check that data is not null
            if (csvinterface_SKIPS.CSVMetaAndColumndata != null)
            {
                Console.WriteLine("The datacolumns capacity is:" + csvinterface.CSVMetaAndColumndata.Count);
                csvinterface_SKIPS.LoadCSVdata(@"C:\testvsc\121121121121\2016y10m03d_19h28m53s_ReactivePwrMap\2016y10m03d_19h28m53s_SN121638052347_S240_60_LL_ReactivePwrMap.csv");
                //populate the data
                //csvinterface.LoadData();
            }
            else
                Console.WriteLine("The datacolumns metadate is null!");

            if (csvinterface_SKIPS.CSVMetaAndColumndata != null)
            {
                foreach (var v in csvinterface_SKIPS.GetColumnData("UO"))
                {
                    Console.WriteLine(v);
                }

            }
            Console.ReadLine();
        }
    }
}
