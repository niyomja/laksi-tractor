using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MySql.Data.MySqlClient;
using System.Data;

namespace dalTractor
{
    public class CustomerDAL
    {
        public static List<Customer> getCustomers() 
        {
            try
            {
                SQLHelper dbhelper = new SQLHelper();

                List<MySqlParameter> lstParameter = new List<MySqlParameter>();

                var resultSet = dbhelper.executeSP<DataSet>(lstParameter, "SelectAllCustomers");

                List<Customer> customers = new List<Customer>();
                foreach (DataRow drow in resultSet.Tables[0].Rows)
                {
                    Customer customer = new Customer();
                    customer.CustomerID = Convert.ToInt32(drow["customerId"].ToString());
                    customer.CustomerName = drow["customerName"].ToString();
                    customer.Contact = drow["contact"].ToString();
                    customer.Address = drow["address"].ToString();
                    customer.Fax = drow["fax"].ToString();
                    customer.TaxNo = drow["tax_no"].ToString();

                    customers.Add(customer);
                }

                return customers;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void create(string customerName, string contact, string address, string fax, string taxNo, int userId)
        {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_CustomerName", customerName));
                lstParameter.Add(new MySqlParameter("_Contact", contact));
                lstParameter.Add(new MySqlParameter("_UserID", userId));

                lstParameter.Add(new MySqlParameter("_Address", address));
                lstParameter.Add(new MySqlParameter("_Fax", fax));
                lstParameter.Add(new MySqlParameter("_TaxNo", taxNo));

                sqlHelper.executenonquery(lstParameter, "CreateCustomer");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void update(int customerId, string customerName, string contact, string address, string fax, string taxNo, int userId)
        {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_CustomerID", customerId));
                lstParameter.Add(new MySqlParameter("_CustomerName", customerName));
                lstParameter.Add(new MySqlParameter("_Contact", contact));
                lstParameter.Add(new MySqlParameter("_UserID", userId));

                lstParameter.Add(new MySqlParameter("_Address", address));
                lstParameter.Add(new MySqlParameter("_Fax", fax));
                lstParameter.Add(new MySqlParameter("_TaxNo", taxNo));

                sqlHelper.executenonquery(lstParameter, "UpdateCustomer");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void delete(int customerId, int userId)
        {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_CustomerID", customerId));
                lstParameter.Add(new MySqlParameter("_UserID", userId));

                sqlHelper.executenonquery(lstParameter, "DeleteCustomer");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    public class Customer {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string TaxNo { get; set; } 
    }

    /*
       `address` text,
       `fax` varchar(20) DEFAULT NULL,
       `tax_no` varchar(100) DEFAULT NULL,
     */
}
