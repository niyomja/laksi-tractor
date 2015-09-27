using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using MySql.Data.MySqlClient;

namespace dalTractor
{
    public class ReportDAL
    {
        public static DataSet getCompanyInfo() {
            try
            {
                SQLHelper dbhelper = new SQLHelper();

                List<MySqlParameter> lstParameter = new List<MySqlParameter>();

                return dbhelper.executeSP(lstParameter, "SelectCompany");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static DataSet getSaleReport(DateTime startDate, DateTime endDate, int brandId)
        {
            try
            {
                SQLHelper dbhelper = new SQLHelper();

                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_StartDate", startDate));
                lstParameter.Add(new MySqlParameter("_EndDate", endDate));
                lstParameter.Add(new MySqlParameter("_BrandID", brandId));

                return dbhelper.executeSP(lstParameter, "SelectSaleReport");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static DataSet getCustomerReport(DateTime startDate, DateTime endDate, int brandId)
        {
            try
            {
                SQLHelper dbhelper = new SQLHelper();

                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_StartDate", startDate));
                lstParameter.Add(new MySqlParameter("_EndDate", endDate));
                lstParameter.Add(new MySqlParameter("_BrandID", brandId));

                return dbhelper.executeSP(lstParameter, "SelectCustomerReport");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
         
        public static DataSet getBalanceReport(DateTime startDate, DateTime endDate, int brandId)
        {
            try
            {
                SQLHelper dbhelper = new SQLHelper();

                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_StartDate", startDate));
                lstParameter.Add(new MySqlParameter("_EndDate", endDate));
                lstParameter.Add(new MySqlParameter("_BrandID", brandId));

                return dbhelper.executeSP(lstParameter, "SelectBalanceReport");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
