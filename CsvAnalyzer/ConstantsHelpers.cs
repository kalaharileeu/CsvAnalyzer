using System;
using System.Collections.Generic;
using System.IO;

namespace CsvAnalyzer
{
    /// <summary>
    /// There are some string in the csv. Trying to deal with them in a tranparant manner
    /// Not sure if this is the best solution.
    /// Create a dictionar lookup to replace the values with float
    /// </summary>
    public class ConstantsHelpers
    {
         ///Pick what conversion function to use
        ///Tests the first value in the list
        ///If it can be float, then convert all to float
        ///else try and replace known words with float
        public static void convertListData(List<string> stringlist, List<float> floatlist)
        {
            float f;
            if (float.TryParse(stringlist[0], out f))
                ConvertToFloat(stringlist, floatlist);
            else
                ReplaceFloat(stringlist, floatlist);//no conversion change all to -1.0

        }
        /// <summary>
        /// Convert values to float. If there are special string values
        /// listed in this class then they need to be converted to float.
        /// </summary>
        private static void ConvertToFloat(List<string> stringlist, List<float> floatlist)
        {
            float f;
            foreach (string value in stringlist)
            {
                f = 0.0f;
                if ((value is string) && (value.Length > 0))
                {
                    try { f = float.Parse(value); }
                    catch (FormatException)
                    {
                        //If the values can not be converted then return empty
                        ReplaceFloat(stringlist, floatlist);
                        return;
                    }
                }
                floatlist.Add(f);
            }
        }
        /// <summary>
        /// if the float value can not be converted then
        /// replace it with a value out of Constant.Dictionary
        /// if it is in the constants dictionary
        /// </summary>
        private static void ReplaceFloat(List<string> stringlist, List<float> floatlist)
        {
            floatlist.Clear();
            for (int j = 0; j < stringlist.Count; j++)
            {
                //Add silly number if not there
                floatlist.Add(-1.0f);
            }
        }

        ///check is a file is open by another program
        public static bool IsFileLocked(FileInfo file)
        {
            //The file does not exist
            if (!file.Exists)
                return true;

            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            //file is not locked
            return false;
        }

    }
}
