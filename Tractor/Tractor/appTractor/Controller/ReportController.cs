using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dalTractor;
using appTractor.View;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using appTractor.Model;
using System.IO;

namespace appTractor.Controller
{
    class ReportController : IControllerBase
    {
        private User user;
        private ucReport view;

        private BrandModel brandModel;
        private ReportModel reportModel;
        private DataSet myData = null;
        private ReportDocument myReport;

        private string reportName;

        delegate void CreateReportDelegate();

        public ReportController() {
            reportModel = new ReportModel();
            view = new ucReport();
            view.Dock = DockStyle.Fill;

            view.btnReport.Click += new EventHandler(btnReport_Click);
            view.chkAll.CheckedChanged += new EventHandler(chkAll_CheckedChanged);
        }

        void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            view.cbBrand.Enabled = !view.chkAll.Checked;
        }

        void btnReport_Click(object sender, EventArgs e)
        {
            CreateReportDelegate CreateReport = null;
            switch (reportName)
            {
                case "balance_report":
                    {
                        CreateReport = new CreateReportDelegate(createBalanceReport);
                    }; break;
                case "sale_report":
                    {
                        CreateReport = new CreateReportDelegate(createSaleReport);
                    }; break;
                case "customer_report":
                    {
                        CreateReport = new CreateReportDelegate(createCustomerReport);
                    }; break;
            }
            if (CreateReport != null)
                CreateReport();
        }

        public void run(IControllerBase ctl)
        {
            var main = (HomeController)ctl;
            user = main.User;

            reportName = main.ReportName;

            main.Body.Controls.Clear();
            main.Body.Controls.Add(view);

            if (reportName == "customer_report")
            {
                view.dtFromDate.Enabled = false;
                view.dtEndDate.Enabled = false;
                view.chkAll.Enabled = false;
                view.cbBrand.Enabled = false;
            }
            else
            {
                brandModel = new BrandModel();

                view.cbBrand.DataSource = brandModel.getBrands();
                view.cbBrand.DisplayMember = "BrandName";
                view.cbBrand.ValueMember = "BrandID";
            }
        }

        //OK
        private void createCustomerReport()
        {
            try
            {
                myReport = new ReportDocument();
                myData = reportModel.getCustomerReport(view.dtFromDate.Value, view.dtEndDate.Value, (view.chkAll.Checked) ? 0 : getSelectedBrand());

                //myData.WriteXml(@".\CustomerReportDataSet.xml", XmlWriteMode.WriteSchema);

                myReport.Load(@".\Report\CRCustomerReport.rpt");

                myReport.Database.Tables[0].SetDataSource(myData.Tables[0]);
                myReport.Database.Tables[1].SetDataSource(myData.Tables[1]);

                view.crystalReportViewer1.ReportSource = myReport;
            }
            catch (CrystalDecisions.CrystalReports.Engine.DataSourceException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            } 
        }

        //OK
        private void createSaleReport()
        {
            try
            {
                myReport = new ReportDocument();
                myData = reportModel.getSaleReport(view.dtFromDate.Value, view.dtEndDate.Value, (view.chkAll.Checked)? 0 : getSelectedBrand());

                //myData.WriteXml(@".\SaleReportDataSet.xml", XmlWriteMode.WriteSchema);

                myReport.Load(@".\Report\CRSaleReport.rpt");

                myReport.Database.Tables[0].SetDataSource(myData.Tables[0]);
                myReport.Database.Tables[1].SetDataSource(myData.Tables[1]);

                view.crystalReportViewer1.ReportSource = myReport;
            }
            catch (CrystalDecisions.CrystalReports.Engine.DataSourceException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            } 
        }
        
        //OK
        private void createBalanceReport()
        {
            try
            {
                myReport = new ReportDocument();
                myData = reportModel.getBalanceReport(view.dtFromDate.Value, view.dtEndDate.Value, (view.chkAll.Checked) ? 0 : getSelectedBrand());

                //myData.WriteXml(@".\BalanceReportDataSet.xml", XmlWriteMode.WriteSchema);

                myReport.Load(@".\Report\CRBalanceReport.rpt");

                myReport.Database.Tables[0].SetDataSource(myData.Tables[0]);
                myReport.Database.Tables[1].SetDataSource(myData.Tables[1]);

                view.crystalReportViewer1.ReportSource = myReport;
            }
            catch (CrystalDecisions.CrystalReports.Engine.DataSourceException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            } 

        }

        private int getSelectedBrand()
        {
            if (view.cbBrand.SelectedValue != null)
                return int.Parse(view.cbBrand.SelectedValue.ToString());
            else
                return 0;
        }

        

        
    }
}
