using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using appTractor.View;
using appTractor.Model;
using dalTractor;
using System.Windows.Forms;

namespace appTractor.Controller
{
    class BrandController : IControllerBase
    {
        private dgBrand view;

        private BrandModel brandModel;

        private User user;

        public BrandController()
        {
            view = new dgBrand();

            view.btnSave.Click += new EventHandler(btnSave_Click);

            brandModel = new BrandModel();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(view.txtBrandname.Text)) {
                    view.txtBrandname.Focus();
                    return;
                }
                Brand brand = new Brand()
                {
                    Brandname = view.txtBrandname.Text,
                    Description = view.txtDescription.Text
                };
                brandModel.createBrand(brand, user.UserID);
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("พบข้อผิดผลาด: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region IControllerBase Members

        public void run(IControllerBase ctl)
        {
            var main = (HomeController)ctl;
            user = main.User;
            view.ShowDialog();
        }

        #endregion
    }
}
