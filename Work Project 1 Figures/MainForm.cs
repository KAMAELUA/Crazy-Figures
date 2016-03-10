using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace Work_Project_1_Figures
{

    
    public partial class MainForm : Form
    {
        private int TIMER_INTERVAL = 50;
        private List<Figure> figures;
        private Timer drawingTimer;

        public MainForm()
        {
            InitializeComponent();
            InitializeElements();
            LocalizeElements();
            InitializeListOfLangs();
        }

        private void LocalizeElements()
        {
            BtnAction.Text = Localization.GetLocalizedString("BtnAction.StartText");

            foreach (TreeNode N in elementsTree.Nodes)
            {
                Type nodeTagType = N.Tag.GetType();

                if (nodeTagType == typeof(Triangle))
                    N.Text = Localization.GetLocalizedString("Triangle");
                else if (nodeTagType == typeof(Circle))
                    N.Text = Localization.GetLocalizedString("Circle");
                else if (nodeTagType == typeof(CustomRectangle))
                    N.Text = Localization.GetLocalizedString("Rectangle");
            }

            this.Text = Localization.GetLocalizedString("FormTitle");
        }

        public void InitializeElements()
        {
            figures = new List<Figure>();
            drawingTimer = new Timer();
            drawingTimer.Tick += DrawingTimer_Tick;
            drawingTimer.Interval = TIMER_INTERVAL;
            drawingTimer.Start();
        }

        public void InitializeListOfLangs()
        {
            languageListBox.Items.Clear();
            String[] langList = Localization.GetSupportedLanguages().Values.ToArray();
            languageListBox.Items.AddRange(Localization.GetSupportedLanguages().Values.ToArray());
        }

        private void DrawingTimer_Tick(object sender, EventArgs e)
        {
            if (figures != null && figures.Count > 0)
            {
                PbMain.Invalidate();
            }
        }
        
        private void elementsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode elementNode = ((TreeView)sender).SelectedNode;
            Figure tmpFigure = (Figure)elementNode.Tag;
            ToggleActionBtn(tmpFigure.isOnMove);
        }

        #region Button func
        private void TriangleBtnClick(object sender, EventArgs e)
        {
            Triangle tmpFigure = new Triangle();
            figures.Add(tmpFigure);

            TreeNode elementNode = new TreeNode(Localization.GetLocalizedString("Triangle"));
            elementNode.ForeColor = tmpFigure.FigureColor;
            elementNode.Tag = tmpFigure;
            elementsTree.Nodes.Add(elementNode);
        }

        private void CircleBtnClick(object sender, EventArgs e)
        {
            Circle tmpFigure = new Circle();
            figures.Add(tmpFigure);

            TreeNode elementNode = new TreeNode(Localization.GetLocalizedString("Circle"));
            elementNode.ForeColor = tmpFigure.FigureColor;
            elementNode.Tag = tmpFigure;
            elementsTree.Nodes.Add(elementNode);
        }

        private void RectangleBtnClick(object sender, EventArgs e)
        {
            CustomRectangle tmpFigure = new CustomRectangle();
            figures.Add(tmpFigure);

            TreeNode elementNode = new TreeNode(Localization.GetLocalizedString("Rectangle"));
            elementNode.ForeColor = tmpFigure.FigureColor;
            elementNode.Tag = tmpFigure;
            elementsTree.Nodes.Add(elementNode);
        }

        public void ToggleActionBtn(Boolean isOnMove)
        {
            if (!BtnAction.Enabled)
                BtnAction.Enabled = true;

            if (isOnMove)
            {
                BtnAction.Text = Localization.GetLocalizedString("BtnAction.StopText");
            }
            else
            {
                BtnAction.Text = Localization.GetLocalizedString("BtnAction.StartText");             
                
            }

        }

        private void BtnAction_Click(object sender, EventArgs e)
        {
            ToggleFigureState();
        }

        

        #endregion Button func

        public void ToggleFigureState()
        {
            Boolean figureState = ((Figure)elementsTree.SelectedNode.Tag).isOnMove;
            if(figureState)
            {
                ((Figure)elementsTree.SelectedNode.Tag).isOnMove = false;
                ToggleActionBtn(false);
            }
            else
            {
                ((Figure)elementsTree.SelectedNode.Tag).isOnMove = true;
                ToggleActionBtn(true);
            }
        }

        private void PbMain_Paint(object sender, PaintEventArgs e)
        {
            Size drawingSize = PbMain.Size;
            foreach (Figure F in figures)
            {
                F.Move(drawingSize);
                F.Draw(e.Graphics);
            }
        }

        private void elementsTree_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Delete == e.KeyData)
            {
                RemoveTreeElement();
            }
        }

        public void RemoveTreeElement()
        {
            TreeNode selectedElement = elementsTree.SelectedNode;
            Boolean isRemoved = figures.Remove((Figure)selectedElement.Tag);
            if (isRemoved)
            {
                elementsTree.Nodes.Remove(selectedElement);
            }

            PbMain.Invalidate();
            if (figures.Count == 0)
                BtnAction.Enabled = false;
        }

        private void languageListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            Dictionary<String, String> langStrings = Localization.GetSupportedLanguages();

            int index = langStrings.Values.ToList().IndexOf(box.SelectedItem.ToString());
            
            String langInTwoLetters = langStrings.Keys.ToArray()[index];
            Localization.ChangeLocale(langInTwoLetters);
            LocalizeElements();
            Localization.ApplyLicalizationForControl(this);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuSaveBtn_Click(object sender, EventArgs e)
        {
            SerializeToJson();
        }

        private byte[] SerializeToBinary()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();

            formatter.Serialize(memStream, figures);
            byte[] obj = memStream.ToArray();
            memStream.Close();
            
            return obj;           
        }

        private String SerializeToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Figure>));
            MemoryStream ms = new MemoryStream();
            serializer.Serialize(ms, figures);
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            
            String str = sr.ReadToEnd();
            ms.Close();

            return str;
        }

        private String SerializeToJson()
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Figure>));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, figures);
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);

            String str = sr.ReadToEnd();
            ms.Close();

            return str;
        }
    }
}
