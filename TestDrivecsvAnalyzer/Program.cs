using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvAnalyzer;

namespace TestDrivecsvAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            DataColumns datacolumns;
            XmlManager<DataColumns> columnloader = new XmlManager<DataColumns>();
            //Initialize the datacolumns class with the wanted columns
            //XML file build action none, Copy if newer
            datacolumns = columnloader.Load("Content/XMLFile1.xml");
            if (datacolumns != null)
            {
                if (datacolumns.namealiaslist.Count < 1)
                    return;
            }
            else
                return;
        }
    }
}
