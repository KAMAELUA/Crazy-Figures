namespace Work_Project_1_Figures
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.languageListBox = new System.Windows.Forms.ComboBox();
            this.RectangleBtn = new System.Windows.Forms.Button();
            this.CircleBtn = new System.Windows.Forms.Button();
            this.BtnAction = new System.Windows.Forms.Button();
            this.BtnTriangle = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileStrimMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCloseBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.elementsTree = new System.Windows.Forms.TreeView();
            this.PbMain = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.languageListBox);
            this.panel1.Controls.Add(this.RectangleBtn);
            this.panel1.Controls.Add(this.CircleBtn);
            this.panel1.Controls.Add(this.BtnAction);
            this.panel1.Controls.Add(this.BtnTriangle);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Name = "panel1";
            // 
            // languageListBox
            // 
            resources.ApplyResources(this.languageListBox, "languageListBox");
            this.languageListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageListBox.FormattingEnabled = true;
            this.languageListBox.Name = "languageListBox";
            this.languageListBox.Sorted = true;
            this.languageListBox.SelectedIndexChanged += new System.EventHandler(this.languageListBox_SelectedIndexChanged);
            // 
            // RectangleBtn
            // 
            resources.ApplyResources(this.RectangleBtn, "RectangleBtn");
            this.RectangleBtn.Name = "RectangleBtn";
            this.RectangleBtn.UseVisualStyleBackColor = true;
            this.RectangleBtn.Click += new System.EventHandler(this.RectangleBtnClick);
            // 
            // CircleBtn
            // 
            resources.ApplyResources(this.CircleBtn, "CircleBtn");
            this.CircleBtn.Name = "CircleBtn";
            this.CircleBtn.UseVisualStyleBackColor = true;
            this.CircleBtn.Click += new System.EventHandler(this.CircleBtnClick);
            // 
            // BtnAction
            // 
            resources.ApplyResources(this.BtnAction, "BtnAction");
            this.BtnAction.Name = "BtnAction";
            this.BtnAction.UseVisualStyleBackColor = true;
            this.BtnAction.Click += new System.EventHandler(this.BtnAction_Click);
            // 
            // BtnTriangle
            // 
            resources.ApplyResources(this.BtnTriangle, "BtnTriangle");
            this.BtnTriangle.Name = "BtnTriangle";
            this.BtnTriangle.UseVisualStyleBackColor = true;
            this.BtnTriangle.Click += new System.EventHandler(this.TriangleBtnClick);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileStrimMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // FileStrimMenuItem
            // 
            resources.ApplyResources(this.FileStrimMenuItem, "FileStrimMenuItem");
            this.FileStrimMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenBtn,
            this.menuSaveBtn,
            this.menuCloseBtn});
            this.FileStrimMenuItem.Name = "FileStrimMenuItem";
            this.FileStrimMenuItem.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menuOpenBtn
            // 
            resources.ApplyResources(this.menuOpenBtn, "menuOpenBtn");
            this.menuOpenBtn.Name = "menuOpenBtn";
            // 
            // menuSaveBtn
            // 
            resources.ApplyResources(this.menuSaveBtn, "menuSaveBtn");
            this.menuSaveBtn.Name = "menuSaveBtn";
            this.menuSaveBtn.Click += new System.EventHandler(this.menuSaveBtn_Click);
            // 
            // menuCloseBtn
            // 
            resources.ApplyResources(this.menuCloseBtn, "menuCloseBtn");
            this.menuCloseBtn.Name = "menuCloseBtn";
            // 
            // elementsTree
            // 
            resources.ApplyResources(this.elementsTree, "elementsTree");
            this.elementsTree.Name = "elementsTree";
            this.elementsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.elementsTree_AfterSelect);
            this.elementsTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.elementsTree_KeyDown);
            // 
            // PbMain
            // 
            resources.ApplyResources(this.PbMain, "PbMain");
            this.PbMain.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbMain.Name = "PbMain";
            this.PbMain.TabStop = false;
            this.PbMain.Paint += new System.Windows.Forms.PaintEventHandler(this.PbMain_Paint);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbMain);
            this.Controls.Add(this.elementsTree);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnTriangle;
        private System.Windows.Forms.TreeView elementsTree;
        private System.Windows.Forms.PictureBox PbMain;
        private System.Windows.Forms.Button BtnAction;
        private System.Windows.Forms.Button CircleBtn;
        private System.Windows.Forms.Button RectangleBtn;
        private System.Windows.Forms.ComboBox languageListBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileStrimMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuOpenBtn;
        private System.Windows.Forms.ToolStripMenuItem menuSaveBtn;
        private System.Windows.Forms.ToolStripMenuItem menuCloseBtn;
    }
}

