using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Work_Project_1_Figures.Figures;

namespace Work_Project_1_Figures
{
    public static class FileManager
    {
        public static Boolean Save(List<Figure> list)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "XML files (*.xml)|*.xml|JSON files (*.json)|*.json|Binary files (*.bin)|*.bin";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileDialog.FilterIndex == 1)
                {
                    StreamWriter file = new StreamWriter(fileDialog.FileName, false);
                    String str = Serializer.SerializeToXml(list);
                    file.WriteLine(str);
                    file.Close();
                }
                else if (fileDialog.FilterIndex == 2)
                {
                    StreamWriter file = new StreamWriter(fileDialog.FileName, false);
                    String str = Serializer.SerializeToJson(list);
                    file.WriteLine(str);
                    file.Close();
                }
                else if (fileDialog.FilterIndex == 3)
                {
                    FileStream file = new FileStream(fileDialog.FileName, FileMode.Create, FileAccess.Write);
                    Byte[] bytes = Serializer.SerializeToByte(list);
                    file.Write(bytes, 0, bytes.Length);
                    file.Close();
                }
            }
            return true;
        }

        public static List<Figure> Open()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "XML files (*.xml)|*.xml|JSON files (*.json)|*.json|Binary files (*.bin)|*.bin";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileDialog.FilterIndex == 1)
                {
                    using (Stream fileStream = fileDialog.OpenFile())
                    {
                        return Serializer.DeserializeFromXml(fileStream);
                    }
                }
                else if (fileDialog.FilterIndex == 2)
                {
                    using (Stream fileStream = fileDialog.OpenFile())
                    {
                        return Serializer.DeserializeFromJson(fileStream);
                    }

                }
                else if (fileDialog.FilterIndex == 3)
                {
                    using (Stream fileStream = fileDialog.OpenFile())
                    {
                        return Serializer.DeserializeFromBinary(fileStream);
                    }

                }
            }
            return new List<Figure>();
        }
    }
}
