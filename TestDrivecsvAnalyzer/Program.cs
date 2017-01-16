using System;
using CsvAnalyzer;

namespace TestDrivecsvAnalyzer
{
    class Program
    {
        static void Main(string[] args)
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
            Console.ReadLine();
        }
    }
}
