using System.Collections.Generic;

namespace CsvAnalyzer
{
    /// <summary>
    /// Implements IBaselist
    /// Valuelist handles the serves column data to user
    /// Two different slice dictionary lookups because I repeat the keys.
    /// If the test ran twice the same set of keys will be reated. LolHil
    /// </summary>
    public class ValuelistI : IBaselist
    {
        public ValuelistI(List<string> stringvaluelist, string columnname, Column column)
        {
            ValueListColumn = column;
            name = columnname;
            slices = new Dictionary<float, List<float>>();
            slices2 = new Dictionary<float, List<float>>();
            valuesfloat = new List<float>();
            valuesstring = stringvaluelist;
            //Convert string/float list to floatlist 
            ConstantsHelpers.convertListData(valuesstring, valuesfloat);
        }

        public void PopulateSlices(Dictionary<float, List<int>> slicedvalues)
        {
            foreach (KeyValuePair<float, List<int>> kv in slicedvalues)
            {
                slices.Add(kv.Key, valuesfloat.GetRange(kv.Value[0], kv.Value[1] - kv.Value[0]));
            }
        }

        //public Dictionary<float, List<float>> GetSlices() { return slices; }

        //public Dictionary<float, List<float>> GetSlices2() { return slices2; }

        //returns the list of floats
        public List<float> GetFloats() { return valuesfloat; }
        //returns the name of the column
        public string GetName() { return name; }
        public int GetScale() { return ValueListColumn.scale; }
        public string Getaccuracystr() { return ValueListColumn.accuracystr; }
        //*******************************Variables***************************
        protected List<float> valuesfloat;
        protected List<string> valuesstring;
        protected Dictionary<float, List<float>> slices;//first dictio
        protected Dictionary<float, List<float>> slices2;//Second dictionary for second set of values
        protected string name;
        protected Column ValueListColumn;

    }
}
