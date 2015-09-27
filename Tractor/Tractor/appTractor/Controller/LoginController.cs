using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using appTractor.View;
using appTractor.Model;
using dalTractor;

namespace appTractor.Controller
{
    class LoginController : IControllerBase
    {
        #region [Private Properties]
        private dgLogin view;
        private HomeController home;
        private UserModel userModel;
        #endregion

        #region [Public Properties]
        public string Username { get { return view.tbUsername.Text; } set { view.tbUsername.Text = value; } }
        public string Password { get { return view.tbPassword.Text; } set { view.tbPassword.Text = value; } }
        public User User { get; set; }

        #endregion

        #region [Default Constructor]
        public LoginController() {
            view = new appTractor.View.dgLogin();
            view.btnLogin.Click += new EventHandler(btnLogin_Click);
            view.FormClosed += new FormClosedEventHandler(view_FormClosed);
            view.btnCancel.Click += new EventHandler(btnCancel_Click);

            home = new HomeController();
            userModel = new UserModel();
        }
        #endregion

        #region [Events Handler]
        void btnLogin_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(view.tbUsername.Text))
            {
                if (!String.IsNullOrEmpty(view.tbPassword.Text))
                {
                    //check user
                    User = userModel.checkLogin(Username, Password);
                    if (User != null)
                    {
                        if (User.Status == 1)
                        {
                            //update last access
                            userModel.updateLastAccess(User.UserID);

                            view.DialogResult = DialogResult.OK;
                            home.run(this);
                        }
                        else
                        {
                            if (MessageBox.Show("บัญชีผู้ใช้ ถูกล็อค ลองใหม่อีกครั้ง ?", "ล็อคอินผิดผลาด", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            {
                                Application.Exit();
                            }
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("ชื่อผู้ใช้ หรือรหัสผ่านไม่ถูกต้อง ลองใหม่อีกครั้ง ?", "ล็อคอินผิดผลาด", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            Application.Exit();
                        }
                    }
                }
                else
                {
                    view.tbPassword.Focus();
                    return;
                }
            }
            else
            {
                view.tbUsername.Focus();
                return;
            }
        }

        void view_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (view.DialogResult != DialogResult.OK)
                Application.Exit();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region IControllerBase Members

        public void run(IControllerBase ctl)
        {
            view.ShowDialog();
        }

        #endregion
    }
}
