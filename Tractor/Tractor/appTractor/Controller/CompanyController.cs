using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dalTractor;
using appTractor.View;
using appTractor.Model;
using System.Windows.Forms;

namespace appTractor.Controller
{
    class CompanyController : IControllerBase
    {
        private dgCommon vcommon;
        private ucCompany view;
        private User user;
        private Company company;
        private CompanyModel companyModel;

        public Company Company { get { return company; } }

        public CompanyController() {
            companyModel = new CompanyModel();

            vcommon = new dgCommon();
            vcommon.Width = 500;

            view = new ucCompany();

            vcommon.Text = "Company Informaion";
            view.Dock = DockStyle.Fill;

            vcommon.Controls.Add(view);

            vcommon.AcceptButton = view.btnOK;

            view.btnOK.Click += new EventHandler(btnOK_Click);
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Company company = new Company()
                {
                    ID= this.company.ID,
                    Name = view.txtCompanyName.Text,
                    Desciption = view.txtDescription.Text,
                    LocG = this.company.LocG,
                    LocIM = this.company.LocIM
                };
                companyModel.UpdateCompany(company, user.UserID);
                this.company = company;
                vcommon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "เกิดข้อผิดผลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void run(IControllerBase ctl)
        {
            var main = (HomeController)ctl;
            user = main.User;
            company = main.Company;
           
            view.txtCompanyName.Text = company.Name;
            view.txtDescription.Text = company.Desciption;

            vcommon.ShowDialog();
        }
    }
}
