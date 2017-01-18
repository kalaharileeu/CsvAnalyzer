using System.Collections.Generic;
using System.IO;

namespace CsvAnalyzer
{
    public class CSVinterface
    {
        public CSVinterface(){}
        /// <summary>
        /// If there is a valid xml data model then feed it here
        /// </summary>
        /// <param name="xmlfilename"></param>
        public void InitializeXmlDataModels(string xmlfilename)
        {
            //have to do basic file check befor continue
            if (!ConstantsHelpers.FileExists(xmlfilename)) return;
            //Convert the string to fileInfo to check if it is locked
            FileInfo fi = new FileInfo(xmlfilename);
            if (ConstantsHelpers.IsFileLocked(fi)) return;
            XmlManager<DataColumns> columnloader = new XmlManager<DataColumns>();
            //Initialize the datacolumns class with the wanted columns
            //XML file build action none, Copy if newer
            //Just populates the metadata
            csvmetaAnddata = columnloader.Load(xmlfilename/*"Content/XMLFile1.xml"*/);
        }
        /// <summary>
        /// Load the data into the csvmetaAnddata instances
        /// </summary>
        /// <param name="csvfilename"></param>
        public void LoadCSVdata(string csvfilename)
        {
            csvqualified_filename = "";//Initialize
            qualifyCSVfile(csvfilename);
            //Clear old data for new plot
            setupandclearolddata();
            LoadData();
        }
        /// <summary>
        /// Check that the file is ready for use
        /// </summary>
        /// <param name="csvfilenanme"></param>
        private void qualifyCSVfile(string csvfilename)
        {
            if (csvmetaAnddata == null)return;
            //have to do basic file check befor continue
            if (!ConstantsHelpers.FileExists(csvfilename)) return;
            //have to do basic file check befor continue
            if (ConstantsHelpers.DirChecks(csvfilename)) return;
            if (csvmetaAnddata == null) return;
            //checks if the fiel is open or in use
            FileInfo fi = new FileInfo(csvfilename);
            if (ConstantsHelpers.IsFileLocked(fi)) return;
            //The filename was check now it is available for use
            csvqualified_filename = csvfilename;
        }
        /// <summary>
        /// Clear the old data for a replot
        /// </summary>
        private void setupandclearolddata()
        {
            //Datacolumns comes from xml so do not clear it
            //Clear to reuse
            if (csvmetaAnddata != null)
            {
                foreach (Column c in csvmetaAnddata.namealiaslist)
                    c.clearvalues();//Clear the values in the columns

                dictColumnAliasData = new Dictionary<string, Column>();
                //columns = new List<IBaselist>();
                //csvqualified_filename = "";
            }
        }
        /// <summary>
        /// Check if the data contains a certain column name
        /// </summary>
        /// <param name="collumnname">Alias name string</param>
        /// <returns>bool</returns>
        public int ContainsColumn(string collumnalias)
        {
            if (csvmetaAnddata == null) return -1;
            int i = csvmetaAnddata.namealiaslist.Count;
            for (int j = 0; j <= i - 1; j++)
                if (collumnalias == csvmetaAnddata.namealiaslist[j].alias)
                    return j;
            return -1;
        }
        /// <summary>
        /// return 
        /// </summary>
        /// <param name="collumnname">Alias name string</param>
        /// <returns>bool</returns>
        public List<string> GetColumnData(string collumnalias)
        {
            int j = ContainsColumn(collumnalias);
            if (j > -1)
                return csvmetaAnddata.namealiaslist[j].Columnvalues;
            else
                return null;
        }
        //Returns a list of all the wanted columns, as per xml
        public List<Column> CSVMetaAndColumndata
        {
            get
            {
                if (csvmetaAnddata != null)
                    //name alias list is a list of column instances
                    return csvmetaAnddata.namealiaslist;
                else
                    return null;
            }
        }
        /// <summary>
        /// populating data for the baseline file values
        /// </summary>
        /// <param name="filename"></param>
        private void LoadData()
        {
            //File was not checked
            if (csvqualified_filename == "" || csvqualified_filename == null) return;
            // Read sample data from CSV file
            using (ReadWriteCsv.CsvFileReader reader = new ReadWriteCsv.CsvFileReader(csvqualified_filename))
            {
                ReadWriteCsv.CsvRow row = new ReadWriteCsv.CsvRow();
                var rowcount = 0;
                //Read row for row
                while (reader.ReadRow(row))
                {
                    //the first row is the here (header)
                    if (rowcount == 0)
                    {
                        foreach (string s in row)
                        {
                            foreach (Column c in csvmetaAnddata.namealiaslist)
                                //if the name is in the wanted columns, save position
                                if (c.columnname == s) c.columnnumber = row.IndexOf(s);
                        }
                    }
                    else
                    {
                        //the other rows handled here. Not the first row
                        foreach (Column c in csvmetaAnddata.namealiaslist)
                            c.colvalues.Add(row[c.columnnumber]);
                    }
                    rowcount++;
                }
                // Debug.WriteLine("Baseline rows imported: " + Convert.ToString(rowcount));
            }

            foreach (Column c in csvmetaAnddata.namealiaslist)
            {
                dictColumnAliasData.Add(c.alias, c);
            }
        }

        //A dictionary of column aliases and data, this dict use for data loading
        Dictionary<string, Column> dictColumnAliasData;
        //Datacolumns is a class holding metadata and data, metadata from xml
        DataColumns csvmetaAnddata;
       // private List<IBaselist> columns;
        string csvqualified_filename;
    }
}
