using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dalTractor;
using System.Data;

namespace appTractor.Model
{
    public class ReportModel : IModelBase
    {
        public DataSet getCompanyInfo() {
            return ReportDAL.getCompanyInfo();
        }

        public DataSet getSaleReport(DateTime startDate, DateTime endDate, int brandId)
        {
            return ReportDAL.getSaleReport(startDate, endDate, brandId);
        }

        public DataSet getCustomerReport(DateTime startDate, DateTime endDate, int brandId)
        {
            return ReportDAL.getCustomerReport(startDate, endDate, brandId);
        }

        public DataSet getBalanceReport(DateTime startDate, DateTime endDate, int brandId)
        {
            return ReportDAL.getBalanceReport(startDate, endDate, brandId);
        }
    }
}
