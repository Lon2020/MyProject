
namespace Assignment_2
{
    partial class TextEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextEditorForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCtrlOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsCtrlShiftSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStrip = new System.Windows.Forms.ToolStripButton();
            this.openToolStrip = new System.Windows.Forms.ToolStripButton();
            this.saveToolStrip = new System.Windows.Forms.ToolStripButton();
            this.saveAsToolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.boldToolStrip = new System.Windows.Forms.ToolStripButton();
            this.italicsToolStrip = new System.Windows.Forms.ToolStripButton();
            this.underlineToolStrip = new System.Windows.Forms.ToolStripButton();
            this.sizeComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.nameAndPermission = new System.Windows.Forms.ToolStripLabel();
            this.namePermission = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.cutToolStrip = new System.Windows.Forms.ToolStripButton();
            this.copyToolStrip = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStrip = new System.Windows.Forms.ToolStripButton();
            this.textbox = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1159, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openCtrlOToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsCtrlShiftSToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openCtrlOToolStripMenuItem
            // 
            this.openCtrlOToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openCtrlOToolStripMenuItem.Image")));
            this.openCtrlOToolStripMenuItem.Name = "openCtrlOToolStripMenuItem";
            this.openCtrlOToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openCtrlOToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.openCtrlOToolStripMenuItem.Text = "Open";
            this.openCtrlOToolStripMenuItem.Click += new System.EventHandler(this.openCtrlOToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsCtrlShiftSToolStripMenuItem
            // 
            this.saveAsCtrlShiftSToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsCtrlShiftSToolStripMenuItem.Image")));
            this.saveAsCtrlShiftSToolStripMenuItem.Name = "saveAsCtrlShiftSToolStripMenuItem";
            this.saveAsCtrlShiftSToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsCtrlShiftSToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.saveAsCtrlShiftSToolStripMenuItem.Text = "Save As";
            this.saveAsCtrlShiftSToolStripMenuItem.Click += new System.EventHandler(this.saveAsCtrlShiftSToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("logOutToolStripMenuItem.Image")));
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutUsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.aboutUsToolStripMenuItem.Text = "About Us...";
            this.aboutUsToolStripMenuItem.Click += new System.EventHandler(this.aboutUsToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStrip,
            this.openToolStrip,
            this.saveToolStrip,
            this.saveAsToolStrip,
            this.toolStripSeparator1,
            this.boldToolStrip,
            this.italicsToolStrip,
            this.underlineToolStrip,
            this.sizeComboBox,
            this.toolStripButton8,
            this.toolStripSeparator2,
            this.nameAndPermission,
            this.namePermission});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1159, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // newToolStrip
            // 
            this.newToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("newToolStrip.Image")));
            this.newToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStrip.Name = "newToolStrip";
            this.newToolStrip.Size = new System.Drawing.Size(29, 25);
            this.newToolStrip.Text = "Create a new file (Ctrl + N)";
            this.newToolStrip.Click += new System.EventHandler(this.newToolStrip_Click);
            // 
            // openToolStrip
            // 
            this.openToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("openToolStrip.Image")));
            this.openToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStrip.Name = "openToolStrip";
            this.openToolStrip.Size = new System.Drawing.Size(29, 25);
            this.openToolStrip.Text = "Open an existing file (Ctrl + O)";
            this.openToolStrip.Click += new System.EventHandler(this.openToolStrip_Click);
            // 
            // saveToolStrip
            // 
            this.saveToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStrip.Image")));
            this.saveToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStrip.Name = "saveToolStrip";
            this.saveToolStrip.Size = new System.Drawing.Size(29, 25);
            this.saveToolStrip.Text = "Save file";
            this.saveToolStrip.Click += new System.EventHandler(this.saveToolStrip_Click);
            // 
            // saveAsToolStrip
            // 
            this.saveAsToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveAsToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStrip.Image")));
            this.saveAsToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAsToolStrip.Name = "saveAsToolStrip";
            this.saveAsToolStrip.Size = new System.Drawing.Size(29, 25);
            this.saveAsToolStrip.Text = "Save as...";
            this.saveAsToolStrip.Click += new System.EventHandler(this.saveAsToolStrip_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // boldToolStrip
            // 
            this.boldToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.boldToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("boldToolStrip.Image")));
            this.boldToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.boldToolStrip.Name = "boldToolStrip";
            this.boldToolStrip.Size = new System.Drawing.Size(29, 25);
            this.boldToolStrip.Text = "Bold the selected text";
            this.boldToolStrip.Click += new System.EventHandler(this.boldToolStrip_Click);
            // 
            // italicsToolStrip
            // 
            this.italicsToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.italicsToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("italicsToolStrip.Image")));
            this.italicsToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.italicsToolStrip.Name = "italicsToolStrip";
            this.italicsToolStrip.Size = new System.Drawing.Size(29, 25);
            this.italicsToolStrip.Text = "Italics the selected text";
            this.italicsToolStrip.Click += new System.EventHandler(this.italicsToolStrip_Click);
            // 
            // underlineToolStrip
            // 
            this.underlineToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.underlineToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("underlineToolStrip.Image")));
            this.underlineToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.underlineToolStrip.Name = "underlineToolStrip";
            this.underlineToolStrip.Size = new System.Drawing.Size(29, 25);
            this.underlineToolStrip.Text = "Underline the selected text";
            this.underlineToolStrip.Click += new System.EventHandler(this.underlineToolStrip_Click);
            // 
            // sizeComboBox
            // 
            this.sizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizeComboBox.Name = "sizeComboBox";
            this.sizeComboBox.Size = new System.Drawing.Size(80, 28);
            this.sizeComboBox.SelectedIndexChanged += new System.EventHandler(this.sizeComboBox_Change);
            this.sizeComboBox.Click += new System.EventHandler(this.sizeComboBox_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton8.Text = "Developer: Sorakrit Wisawapakron 13754306  Application .NET assignment 2 contact:" +
    "sorakrit.wisawapakorn-1@student.uts.edu.au";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // nameAndPermission
            // 
            this.nameAndPermission.Name = "nameAndPermission";
            this.nameAndPermission.Size = new System.Drawing.Size(0, 25);
            // 
            // namePermission
            // 
            this.namePermission.Name = "namePermission";
            this.namePermission.Size = new System.Drawing.Size(0, 25);
            this.namePermission.Click += new System.EventHandler(this.namePermission_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolStrip2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStrip,
            this.copyToolStrip,
            this.pasteToolStrip});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(0, 126);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(30, 93);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // cutToolStrip
            // 
            this.cutToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStrip.Image")));
            this.cutToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStrip.Name = "cutToolStrip";
            this.cutToolStrip.Size = new System.Drawing.Size(28, 24);
            this.cutToolStrip.Text = "Cut the selected text";
            this.cutToolStrip.Click += new System.EventHandler(this.cutToolStrip_Click);
            // 
            // copyToolStrip
            // 
            this.copyToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStrip.Image")));
            this.copyToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStrip.Name = "copyToolStrip";
            this.copyToolStrip.Size = new System.Drawing.Size(28, 24);
            this.copyToolStrip.Text = "Copy the selected text";
            this.copyToolStrip.Click += new System.EventHandler(this.copyToolStrip_Click);
            // 
            // pasteToolStrip
            // 
            this.pasteToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStrip.Image")));
            this.pasteToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStrip.Name = "pasteToolStrip";
            this.pasteToolStrip.Size = new System.Drawing.Size(28, 24);
            this.pasteToolStrip.Text = "Paste the copy text";
            this.pasteToolStrip.Click += new System.EventHandler(this.pasteToolStrip_Click);
            // 
            // textbox
            // 
            this.textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox.Location = new System.Drawing.Point(33, 79);
            this.textbox.Name = "textbox";
            this.textbox.Size = new System.Drawing.Size(1090, 735);
            this.textbox.TabIndex = 4;
            this.textbox.Text = "";
            this.textbox.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // TextEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1159, 849);
            this.Controls.Add(this.textbox);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TextEditorForm";
            this.Text = "Text Editor";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCtrlOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsCtrlShiftSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openToolStrip;
        private System.Windows.Forms.ToolStripButton saveToolStrip;
        private System.Windows.Forms.ToolStripButton saveAsToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton boldToolStrip;
        private System.Windows.Forms.ToolStripButton italicsToolStrip;
        private System.Windows.Forms.ToolStripButton underlineToolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton cutToolStrip;
        private System.Windows.Forms.ToolStripButton copyToolStrip;
        private System.Windows.Forms.ToolStripButton pasteToolStrip;
        private System.Windows.Forms.RichTextBox textbox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripComboBox sizeComboBox;
        private System.Windows.Forms.ToolStripLabel nameAndPermission;
        private System.Windows.Forms.ToolStripLabel namePermission;
        private System.Windows.Forms.ToolStripButton newToolStrip;
    }
}