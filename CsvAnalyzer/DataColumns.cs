using System.Collections.Generic;
using System.Xml.Serialization;

namespace CsvAnalyzer
{
    /// <summary>
    /// This class will contain a list of wanted columns
    /// this list will be deserialized from xml file 
    /// </summary>
    public class DataColumns
    {
        [XmlElement("Column")]
        public List<Column> namealiaslist;

        public DataColumns()
        {
            namealiaslist = new List<Column>();
        }
    }
}
