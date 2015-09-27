namespace appTractor.View
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("รายงานสินค้าคงคลัง", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("รายงานการขาย", 0);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("รายงานลูกค้า", 0);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBrandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companyInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvBrand = new System.Windows.Forms.ListView();
            this.clName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgBrandList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvReport = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageReportList = new System.Windows.Forms.ImageList(this.components);
            this.panelPage = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddNewPart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExitPg = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelBrandName = new System.Windows.Forms.ToolStripLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelPage.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(777, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBrandToolStripMenuItem,
            this.customerToolStripMenuItem1,
            this.userToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newBrandToolStripMenuItem
            // 
            this.newBrandToolStripMenuItem.Name = "newBrandToolStripMenuItem";
            this.newBrandToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newBrandToolStripMenuItem.Text = "&New Brand";
            // 
            // customerToolStripMenuItem1
            // 
            this.customerToolStripMenuItem1.Name = "customerToolStripMenuItem1";
            this.customerToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.customerToolStripMenuItem1.Text = "&Customer";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.userToolStripMenuItem.Text = "&User";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(129, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companyInfoToolStripMenuItem,
            this.backgroundToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionToolStripMenuItem.Text = "&Option";
            // 
            // companyInfoToolStripMenuItem
            // 
            this.companyInfoToolStripMenuItem.Name = "companyInfoToolStripMenuItem";
            this.companyInfoToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.companyInfoToolStripMenuItem.Text = "&Company";
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.backgroundToolStripMenuItem.Text = "&Background";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 393);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(777, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lvBrand);
            this.groupBox1.Location = new System.Drawing.Point(11, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(652, 119);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "แบรนด์";
            // 
            // lvBrand
            // 
            this.lvBrand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBrand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvBrand.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clName,
            this.clDescription});
            this.lvBrand.FullRowSelect = true;
            this.lvBrand.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvBrand.LargeImageList = this.imgBrandList;
            this.lvBrand.Location = new System.Drawing.Point(18, 19);
            this.lvBrand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvBrand.MultiSelect = false;
            this.lvBrand.Name = "lvBrand";
            this.lvBrand.Size = new System.Drawing.Size(619, 85);
            this.lvBrand.TabIndex = 0;
            this.lvBrand.UseCompatibleStateImageBehavior = false;
            // 
            // clName
            // 
            this.clName.Text = "Name";
            this.clName.Width = 273;
            // 
            // clDescription
            // 
            this.clDescription.Text = "Description";
            this.clDescription.Width = 446;
            // 
            // imgBrandList
            // 
            this.imgBrandList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgBrandList.ImageStream")));
            this.imgBrandList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgBrandList.Images.SetKeyName(0, "settings.png");
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lvReport);
            this.groupBox2.Location = new System.Drawing.Point(13, 178);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(650, 138);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "รายงาน";
            // 
            // lvReport
            // 
            this.lvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            listViewItem1.Tag = "balance_report";
            listViewItem1.ToolTipText = "รายงานสินค้าคงคลัง";
            listViewItem2.Tag = "sale_report";
            listViewItem2.ToolTipText = "รายงานการขาย";
            listViewItem3.Tag = "customer_report";
            listViewItem3.ToolTipText = "รายงานลูกค้า";
            this.lvReport.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.lvReport.LargeImageList = this.imageReportList;
            this.lvReport.Location = new System.Drawing.Point(16, 32);
            this.lvReport.Name = "lvReport";
            this.lvReport.Size = new System.Drawing.Size(619, 92);
            this.lvReport.TabIndex = 0;
            this.lvReport.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // imageReportList
            // 
            this.imageReportList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageReportList.ImageStream")));
            this.imageReportList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageReportList.Images.SetKeyName(0, "Document.png");
            // 
            // panelPage
            // 
            this.panelPage.BackColor = System.Drawing.Color.White;
            this.panelPage.Controls.Add(this.panelBody);
            this.panelPage.Controls.Add(this.toolStrip1);
            this.panelPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPage.Location = new System.Drawing.Point(0, 24);
            this.panelPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelPage.Name = "panelPage";
            this.panelPage.Size = new System.Drawing.Size(674, 294);
            this.panelPage.TabIndex = 1;
            this.panelPage.Visible = false;
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.Color.White;
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 39);
            this.panelBody.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(674, 255);
            this.panelBody.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonBack,
            this.toolStripButtonAddNewPart,
            this.toolStripButtonExitPg,
            this.toolStripSeparator1,
            this.toolStripLabelBrandName});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(674, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonBack
            // 
            this.toolStripButtonBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBack.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBack.Image")));
            this.toolStripButtonBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBack.Name = "toolStripButtonBack";
            this.toolStripButtonBack.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonBack.Text = "กลับเมนูหลัก";
            // 
            // toolStripButtonAddNewPart
            // 
            this.toolStripButtonAddNewPart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddNewPart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddNewPart.Image")));
            this.toolStripButtonAddNewPart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddNewPart.Name = "toolStripButtonAddNewPart";
            this.toolStripButtonAddNewPart.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonAddNewPart.Text = "เพิ่ม Part No. ใหม่";
            this.toolStripButtonAddNewPart.Visible = false;
            // 
            // toolStripButtonExitPg
            // 
            this.toolStripButtonExitPg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExitPg.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExitPg.Image")));
            this.toolStripButtonExitPg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExitPg.Name = "toolStripButtonExitPg";
            this.toolStripButtonExitPg.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonExitPg.Text = "ออกจากโปรแกรม";
            this.toolStripButtonExitPg.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabelBrandName
            // 
            this.toolStripLabelBrandName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabelBrandName.ForeColor = System.Drawing.Color.SteelBlue;
            this.toolStripLabelBrandName.Name = "toolStripLabelBrandName";
            this.toolStripLabelBrandName.Size = new System.Drawing.Size(105, 36);
            this.toolStripLabelBrandName.Text = "Brand Name";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(777, 415);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "Company Name:";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panelPage.ResumeLayout(false);
            this.panelPage.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem newBrandToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ListView lvBrand;
        private System.Windows.Forms.ColumnHeader clName;
        private System.Windows.Forms.ColumnHeader clDescription;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Panel panelPage;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton toolStripButtonBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripLabel toolStripLabelBrandName;
        public System.Windows.Forms.ToolStripButton toolStripButtonExitPg;
        public System.Windows.Forms.Panel panelBody;
        public System.Windows.Forms.ToolStripButton toolStripButtonAddNewPart;
        public System.Windows.Forms.ImageList imgBrandList;
        public System.Windows.Forms.ListView lvReport;
        private System.Windows.Forms.ImageList imageReportList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem companyInfoToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;


    }
}

