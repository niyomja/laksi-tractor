using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using appTractor.View;
using dalTractor;
using System.Windows.Forms;
using appTractor.Model;

namespace appTractor.Controller
{
    class UserController : IControllerBase
    {
        private dgCommon vcommon;
        private ucUser view;
        private User user;

        private UserModel userModel;

        public UserController() {
            userModel = new UserModel();

            vcommon = new dgCommon();
            vcommon.Width = 940;

            view = new ucUser();

            vcommon.Text = "User";
            view.Dock = DockStyle.Fill;

            vcommon.Controls.Add(view);

            vcommon.CancelButton = view.btnClose;

            view.dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);

            view.dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dataGridView1_DataError);

            view.bindingSource1.DataSource = userModel.getAllUsers();

            view.toolBtnDelete.Click += new EventHandler(toolBtnDelete_Click);
            view.btnClose.Click += new EventHandler(btnClose_Click);
        }

        void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        void toolBtnDelete_Click(object sender, EventArgs e)
        {
            if (view.bindingSource1.Current != null)
            {
                var user = (User)view.bindingSource1.Current;
                if (!String.IsNullOrEmpty(user.Username) && MessageBox.Show("ต้องการลบข้อมูลของ User " + user.Username + " ใช่ หรือไม่ ?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
                try
                {
                    if (user.UserID > 0)
                    {
                        userModel.delete(user.UserID, this.user.UserID);
                    }

                    //reload data
                    view.bindingSource1.DataSource = userModel.getAllUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "เกิดข้อผิดผลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (view.bindingSource1.Current != null)
            {
                try
                {
                    var user = (User)view.bindingSource1.Current;
                    if (user.UserID > 0)
                    {
                        userModel.update(user, this.user.UserID);
                    }
                    else
                    {
                        if (userModel.add(user, this.user.UserID))
                        {
                            //reload data
                            view.bindingSource1.DataSource = userModel.getAllUsers();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "เกิดข้อผิดผลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            vcommon.Close();
        }

        public void run(IControllerBase ctl)
        {
            var main = (HomeController)ctl;
            user = main.User;
            vcommon.ShowDialog();
        }
    }
}
