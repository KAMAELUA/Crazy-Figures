using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work_Project_1_Figures
{
    public static class FileManager
    {
        public static Boolean Save(List<Figure> list)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "XML files (*.xml)|*.xml|JSON files (*.json)|*.json|Binary files (*.bin)|*.bin";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                if(sf.FilterIndex == 1)
                {
                    StreamWriter file = new StreamWriter(sf.FileName, false);
                    String str = Serializer.SerializeToXml(list);
                    file.WriteLine(list);
                    file.Close();
                }
                else if (sf.FilterIndex == 2)
                {
                    StreamWriter file = new StreamWriter(sf.FileName, false);
                    String str = Serializer.SerializeToJson(list);
                    file.WriteLine(str);
                    file.Close();
                }
                else if (sf.FilterIndex == 3)
                {
                    FileStream file = new FileStream(sf.FileName, FileMode.Create, FileAccess.Write);
                    Byte[] bytes = Serializer.SerializeToByte(list);
                    file.Write(bytes, 0, bytes.Length);
                    file.Close();
                }
            }
            return true;
        }
    }
}
