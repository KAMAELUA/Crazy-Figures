using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Work_Project_1_Figures.Figures;

namespace Work_Project_1_Figures
{
    public static class Serializer
    {
        public static String SerializeToJson(List<Figure> list)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Figure>));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, list);
            ms.Position = 0;
            try
            {
                return new StreamReader(ms).ReadToEnd();
            }
            finally
            {
                ms.Close();
            }            
        }

        public static String SerializeToXml(List<Figure> list)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Figure>));
            MemoryStream ms = new MemoryStream();
            serializer.Serialize(ms, list);
            ms.Position = 0;
           
            try
            {
                return new StreamReader(ms).ReadToEnd();
            }
            finally
            {
                ms.Close();
            }
        }

        public static byte[] SerializeToByte(List<Figure> list)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();

            formatter.Serialize(memStream, list);
            try
            {
                return memStream.ToArray();
            }
            finally
            {
                memStream.Close();
            }
        }

        public static List<Figure> DeserializeFromXml(Stream xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Figure>));
            List<Figure> list = (List<Figure>)serializer.Deserialize(xmlString);
            return list;
        }

        public static List<Figure> DeserializeFromJson(Stream jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Figure>));
            List<Figure> list = (List<Figure>) ser.ReadObject(jsonString);
            return list;
        }

        public static List<Figure> DeserializeFromBinary(Stream binaryStream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            List<Figure> list = (List<Figure>)formatter.Deserialize(binaryStream);
            return list;
        }

    }
}
