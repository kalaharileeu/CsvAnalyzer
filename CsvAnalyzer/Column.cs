﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace CsvAnalyzer
{
/// <summary>
///Column has name, alias anme, columnNumber, from and column data
///Class DataColumns is composed of Columns
///scale is to scale the value out of csv(mV to V)
///Accuracy is the value dependant to verify accuracy
/// </summary>
    public class Column
    {
        public string columnname;
        public string alias;
        public string from;
        public int scale;
        public string accuracystr;
        [XmlIgnore]
        public int columnnumber;
        //This is a list of values contained in the CSV.
        public List<string> colvalues;
        /// <summary>
        /// Clears the values in the list
        /// </summary>
        public void clearvalues()
        {
            if (colvalues.Count > 0)
                colvalues.Clear();
        }
        /// <summary>
        /// Return all the values in the list
        /// Return List of string
        /// /// </summary>
        public List<string> Columnvalues
        {
            get
            {
                return colvalues;
            }
        }

        public Column(){ }
    }
}
