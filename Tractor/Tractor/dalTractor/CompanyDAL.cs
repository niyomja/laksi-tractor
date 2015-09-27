using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MySql.Data.MySqlClient;
using System.Data;

namespace dalTractor
{
    public class CompanyDAL
    {
        public static Company getCompany()
        {
            try 
            {
                SQLHelper dbhelper = new SQLHelper();

                List<MySqlParameter> lstParameter = new List<MySqlParameter>();

                var resultSet = dbhelper.executeSP<DataSet>(lstParameter, "SelectCompany");

                Company company = new Company();
                foreach (DataRow drow in resultSet.Tables[0].Rows)
                {
                    company.ID = Convert.ToInt32(drow["Id"].ToString());
                    company.Name = drow["companyName"].ToString();
                    company.Desciption = drow["description"].ToString();
                    company.LocG = drow["locationG"].ToString();
                    company.LocIM = drow["locationIM"].ToString();

                }
                return company;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void Update(int id, string companyName, string description, string locG, string locIM, int userId){
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_ID", id));
                lstParameter.Add(new MySqlParameter("_CompanyName", companyName));
                lstParameter.Add(new MySqlParameter("_Description", description));
                lstParameter.Add(new MySqlParameter("_LocG", locG));
                lstParameter.Add(new MySqlParameter("_LocIM", locIM));
                lstParameter.Add(new MySqlParameter("_UserID", userId));

                sqlHelper.executenonquery(lstParameter, "UpdateCompany");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    public class Company {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }
        public string LocG { get; set; }
        public string LocIM { get; set; }
    }
}
