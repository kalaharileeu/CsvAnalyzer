using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAnalyzer
{
    public class CSVinterface
    {
        public DataColumns CSVmetadata(string xmlfilename)
        {
            //Convert the string to fileInfo to check if it is locked
            FileInfo fi = new FileInfo(xmlfilename);
            if(ConstantsHelpers.IsFileLocked(fi))
                return null;
            DataColumns datacolumns;
            XmlManager<DataColumns> columnloader = new XmlManager<DataColumns>();
            //Initialize the datacolumns class with the wanted columns
            //XML file build action none, Copy if newer
            datacolumns = columnloader.Load(xmlfilename/*"Content/XMLFile1.xml"*/);
            if (datacolumns != null)
            {
                if (datacolumns.namealiaslist.Count < 1)
                    return null;
                else
                    return datacolumns;
            }
            else
                return null;
        }

        private void IsFileLocked(string xmlfilename)
        {
            throw new NotImplementedException();
        }
    }
}
