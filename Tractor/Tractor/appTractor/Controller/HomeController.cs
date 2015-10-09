using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using appTractor.View;
using System.Windows.Forms;
using dalTractor;
using appTractor.Model;
using System.Drawing;
using System.Collections;
using System.IO;

namespace appTractor.Controller
{
    class HomeController : IControllerBase
    {
        #region [Private Properties]
        private frmMain view;
        private User user;
        private Company company;

        private BrandController brandController;

        private BrandModel brandModel;

        private int selectedBrandId;

        private string selectedReport;

        #endregion

        #region [Public Properties]

        public User User { get { return user; } }
        public Company Company { get { return company; } }
        public int BrandID { get { return selectedBrandId; } }

        public Panel Body { get { return view.panelBody; } }

        public string ReportName { get { return selectedReport; } }
            

        #endregion

        #region [Default Constructor]
        public HomeController() {
            view = new frmMain();

            //add controls to formmain
            view.Controls.Add(view.panelPage);
            view.Controls.Add(view.groupBox2);
            view.Controls.Add(view.groupBox1);

            view.Load += new EventHandler(view_Load);

            view.FormClosing += new FormClosingEventHandler(view_FormClosing);

            //File Menu Items
            view.newBrandToolStripMenuItem.Click += new EventHandler(newBrandToolStripMenuItem_Click);
            view.customerToolStripMenuItem1.Click += new EventHandler(customerToolStripMenuItem1_Click);
            view.userToolStripMenuItem.Click += new EventHandler(userToolStripMenuItem_Click);
            view.exitToolStripMenuItem.Click += new EventHandler(exitToolStripMenuItem_Click);

            //option menu items
            view.companyInfoToolStripMenuItem.Click += new EventHandler(companyInfoToolStripMenuItem_Click);
            view.backgroundToolStripMenuItem.Click += new EventHandler(backgroundToolStripMenuItem_Click);


            view.lvBrand.Click += new EventHandler(lvBrand_Click);

            view.lvReport.Click += new EventHandler(lvReport_Click);

            view.toolStripButtonBack.Click += new EventHandler(toolStripButtonBack_Click);
            view.toolStripButtonExitPg.Click += new EventHandler(toolStripButtonExitPg_Click);

            //disable admin menu
            enable_menu_admin(false);

            brandController = new BrandController();
            brandModel = new BrandModel();

            if (File.Exists(@".\backgroung"))
            {
                try
                {
                    view.BackgroundImage = Image.FromFile(@".\backgroung");
                }
                catch { }
            }
        }

        void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "JPeg file (*.JPG)|*.jpg|Bitmap file (*.BMP)|*.bmp |PNG file (*.PNG)|*.png";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    view.BackgroundImage = Image.FromFile(open.FileName);
                    view.BackgroundImage.Save(@".\backgroung");
                }
            }
            catch { }
        }

        void lvReport_Click(object sender, EventArgs e)
        {
            var lv = view.lvReport;
            view.toolStripLabelBrandName.Text = "";

            if (lv.FocusedItem != null)
            {
                var item = lv.Items[lv.FocusedItem.Index];

                selectedReport = item.Tag.ToString();
                view.toolStripLabelBrandName.Text = item.Text;

                view.menuStrip1.Visible = false;
                view.panelPage.Visible = true;

                ReportController reportController = new ReportController();
                reportController.run(this);

            }
        }

        void companyInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyController companyController = new CompanyController();
            companyController.run(this);
            company = companyController.Company;
            view.Text = company.Name;
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserController userController = new UserController();
            userController.run(this);
        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CustomerController customerController = new CustomerController();
            customerController.run(this);
        }

        #endregion

        #region IControllerBase Members

        public void run(IControllerBase ctl)
        {
            var login = (LoginController)ctl;
            user = login.User;
            view.toolStripStatusLabel1.Text = "User: "+ user.FirstName + " " + user.LastName;

            //admin only manage user 
            enable_menu_admin(user.RoleAdmin == 1);

            //company
            CompanyModel companyModel = new CompanyModel();
            company = companyModel.getCompany();

            view.Text = company.Name + " - Version 1.2.1";

            view.Show();
        }

        private void enable_menu_admin(bool enabled)
        {
            view.userToolStripMenuItem.Visible = enabled;
            view.companyInfoToolStripMenuItem.Visible = enabled;
        }

        #endregion

        #region [Events Handler]

        private void view_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("ออกจากโปรแกรม ใช่หรือไม่ ?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
                view.FormClosing -= new FormClosingEventHandler(view_FormClosing);
                Application.Exit();
            }
            else {
                e.Cancel = true;
            }
            return;
        }

        private void view_Load(object sender, EventArgs e)
        {
            buildBrandList();
        }

        private void buildBrandList()
        {
            var brands = brandModel.getBrands();
            view.lvBrand.Items.Clear();
           
            foreach (Brand brand in brands)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = brand.BrandID;
                item.ImageIndex = 0;
                item.Text = brand.Brandname;
                item.SubItems.Add(brand.Description);
                view.lvBrand.Items.Add(item);
            }
        }

        private void newBrandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            brandController.run(this);
            buildBrandList(); 
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view.Close();
        }

        private void toolStripButtonExitPg_Click(object sender, EventArgs e)
        {
            view.Close();
        }

        private void lvBrand_Click(object sender, EventArgs e)
        {
            var lv = view.lvBrand;
            view.toolStripLabelBrandName.Text = "";

            if (lv.FocusedItem != null)
            {
                var item = lv.Items[lv.FocusedItem.Index];

                selectedBrandId = Convert.ToInt32(item.Tag.ToString());
                view.toolStripLabelBrandName.Text = item.Text;

                enterInventory();
            }
        }

        private void enterInventory()
        {
            //view.toolStripButtonAddNewPart.Visible = true;
            view.menuStrip1.Visible = false;
            view.panelPage.Visible = true;

            InventoryController inventoryController = new InventoryController();
            inventoryController.run(this);
        }

        private void lvBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
           var lv = view.lvBrand;
           view.toolStripLabelBrandName.Text = "";

           if (lv.FocusedItem != null)
           {
               var item = lv.Items[lv.FocusedItem.Index];
               selectedBrandId = Convert.ToInt32(item.Tag.ToString());
               view.toolStripLabelBrandName.Text = item.Text;
           }
        }

        private void toolStripButtonBack_Click(object sender, EventArgs e)
        {
            view.toolStripButtonAddNewPart.Visible = false;
            view.panelPage.Visible = false; 
            view.menuStrip1.Visible = true;
        }

        #endregion
       
    }
}
