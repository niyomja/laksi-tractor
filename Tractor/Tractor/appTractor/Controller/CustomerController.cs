using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using appTractor.View;
using System.Windows.Forms;
using appTractor.Model;
using dalTractor;

namespace appTractor.Controller
{
    class CustomerController : IControllerBase
    {
        private dgCommon vcommon;
        private ucCustomer view;
        private User user;
        private CustomerModel customerModel;

        public CustomerController() {

            customerModel = new CustomerModel();

            vcommon = new dgCommon();
            view = new ucCustomer();

            vcommon.Text = "Customer";
            vcommon.Width = 870;

            view.Dock = DockStyle.Fill;

            vcommon.Controls.Add(view);

            vcommon.CancelButton = view.btnClose;

            view.dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);

            view.bindingSource1.DataSource = customerModel.getAllCustomers();

            view.toolBtnDelete.Click += new EventHandler(toolBtnDelete_Click);
            view.btnClose.Click += new EventHandler(btnClose_Click);

        }

        void toolBtnDelete_Click(object sender, EventArgs e)
        {
            if (view.bindingSource1.Current != null)
            {
                var customer = (Customer)view.bindingSource1.Current;
                if (!String.IsNullOrEmpty(customer.CustomerName) && MessageBox.Show("ต้องการลบข้อมูลของ Customer " + customer.CustomerName + " ใช่ หรือไม่ ?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
                try
                {
                    if (customer.CustomerID > 0)
                    {
                        customerModel.delete(customer.CustomerID, user.UserID);
                    }

                    //reload data
                    view.bindingSource1.DataSource = customerModel.getAllCustomers();
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
                    var customer = (Customer)view.bindingSource1.Current;
                    if (customer.CustomerID > 0)
                    {
                        customerModel.update(customer, user.UserID);
                    }
                    else
                    {
                        customerModel.add(customer, user.UserID);
                        //reload data
                        view.bindingSource1.DataSource = customerModel.getAllCustomers();
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
