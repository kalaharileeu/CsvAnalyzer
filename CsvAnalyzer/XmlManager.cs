using System;
using System.Xml.Serialization;
using System.IO;

namespace CsvAnalyzer
{
    public class XmlManager<T>
    {
        public Type Type;

        public XmlManager()
        {
            Type = typeof(T);
        }
        //Will return default(null) state of T is xml file not exist
        public T Load(string path)
        {
            if (File.Exists(path))
            {
                T instance;
                using (TextReader reader = new StreamReader(path))
                {
                    XmlSerializer xml = new XmlSerializer(Type);
                    instance = (T)xml.Deserialize(reader);
                }
                return instance;
            }
            //return default object if no file exist
            return default(T);
        }

        public void Save(string path, object obj)
        {
            using (TextWriter writer = new StreamWriter(path))
            {
                XmlSerializer xml = new XmlSerializer(Type);
                xml.Serialize(writer, obj);
            }
        }
    }
}