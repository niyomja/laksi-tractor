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
    class PartController : IControllerBase
    {
        private dgPart view;

        private User user;
        private int brandId;
        private PartModel partModel;

        public PartController() {
            view = new dgPart();

            view.btnSave.Click += new EventHandler(btnSave_Click);
            view.btnCancel.Click += new EventHandler(btnCancel_Click);

            partModel = new PartModel();
        }

        #region IControllerBase Members

        public void run(IControllerBase ctl)
        {
            var main = (HomeController)ctl;
            user = main.User;
            brandId = main.BrandID;
            view.ShowDialog();
        }

        #endregion

        void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(view.txtPartNo.Text))
            {
                if (!String.IsNullOrEmpty(view.txtPartName.Text))
                {
                    try
                    {
                        Part part = new Part()
                        {
                            BrandID = brandId,
                            PartNo = view.txtPartNo.Text,
                            PartName = view.txtPartName.Text,
                            Model = view.txtModel.Text,
                            GSP =  Convert.ToDecimal(view.txtGSP.Text),
                            IMSP = Convert.ToDecimal(view.txtIMSP.Text),
                            
                            Status = 1
                        };
                        partModel.createPart(part, user.UserID);
                        view.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("พบข้อผิดผลาด: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else {
                    view.txtPartName.Focus();
                }
            }
            else {
                view.txtPartNo.Focus();
            }
            return;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            view.Close();
        }
    }
}
