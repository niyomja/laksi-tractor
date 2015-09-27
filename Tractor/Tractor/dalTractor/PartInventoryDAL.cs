using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MySql.Data.MySqlClient;
using System.Data;

namespace dalTractor
{
    public class PartInventoryDAL
    {
        public static int create(int partId, DateTime date, string DOInvoiceNo, int customerId, int recd, int lSold, int gOnHand, decimal price,int oemRecd, int rSold, int imOnHand, decimal price2, int totalAvailabel, int totalDemand, string detail, int userId)
        {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_PartID", partId));
                lstParameter.Add(new MySqlParameter("_Date", date));
                lstParameter.Add(new MySqlParameter("_DOInvoiceNo", DOInvoiceNo));
                lstParameter.Add(new MySqlParameter("_Recd", recd));
                lstParameter.Add(new MySqlParameter("_LSold", lSold));
                lstParameter.Add(new MySqlParameter("_GOnHand", gOnHand));
                lstParameter.Add(new MySqlParameter("_Price", price));
                lstParameter.Add(new MySqlParameter("_OEMRecd", oemRecd));
                lstParameter.Add(new MySqlParameter("_RSold", rSold));
                lstParameter.Add(new MySqlParameter("_IMOnHand", imOnHand));
                lstParameter.Add(new MySqlParameter("_Price2", price2));
                lstParameter.Add(new MySqlParameter("_TotalAvailabel", totalAvailabel));
                lstParameter.Add(new MySqlParameter("_TotalDemand", totalDemand));
                lstParameter.Add(new MySqlParameter("_UserID", userId));
                lstParameter.Add(new MySqlParameter("_Detail", detail));

                sqlHelper.executenonquery(lstParameter, "CreatePartInventory");

                return sqlHelper.lastInsertId();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<PartInventory> getPartInventories(int partId)
        {
            try
            {
                SQLHelper dbhelper = new SQLHelper();

                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_PartID", partId));

                var resultSet = dbhelper.executeSP<DataSet>(lstParameter, "SelectPartInventoryByPartId");

                List<PartInventory> partInventories = new List<PartInventory>();
                foreach (DataRow drow in resultSet.Tables[0].Rows)
                {
                    PartInventory partInventory = new PartInventory();
                    partInventory.partInventoryId = Convert.ToInt32(drow["partInventoryId"].ToString());
                    partInventory.partId = Convert.ToInt32(drow["partId"].ToString());
                    partInventory.customerId = (!string.IsNullOrEmpty(drow["customerId"].ToString())) ? Convert.ToInt32(drow["customerId"].ToString()) : 0;
                    partInventory.customerName = drow["customerName"].ToString();
                    partInventory.regDate = Convert.ToDateTime(drow["regDate"].ToString());
                    partInventory.DOInvoiceNo = drow["DOInvoiceNo"].ToString();
                    partInventory.recd = Convert.ToInt32(drow["recd"].ToString());
                    partInventory.lSold = Convert.ToInt32(drow["lSold"].ToString());
                    partInventory.gOnHand = Convert.ToInt32(drow["gOnHand"].ToString());
                    partInventory.oemRecd = Convert.ToInt32(drow["oemRecd"].ToString());
                    partInventory.price = Convert.ToDecimal(drow["price"].ToString());
                    partInventory.rSold = Convert.ToInt32(drow["rSold"].ToString());
                    partInventory.imOnHand = Convert.ToInt32(drow["imOnHand"].ToString());
                    partInventory.price2 = Convert.ToDecimal(drow["price2"].ToString());
                    partInventory.totalAvailabel = Convert.ToInt32(drow["totalAvailabel"].ToString());
                    partInventory.totalDemand = Convert.ToInt32(drow["totalDemand"].ToString());
                    partInventory.detail = drow["detail"].ToString();

                    partInventories.Add(partInventory);
                }

                return partInventories;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void update(int partInventoryId, int partId, DateTime date, string DOInvoiceNo, int customerId, int recd, int lSold, int gOnHand, decimal price, int oemRecd, int rSold, int imOnHand,  decimal price2, int totalAvailabel, int totalDemand, string detail, int userId)
        {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();

                lstParameter.Add(new MySqlParameter("_PartInventoryID", partInventoryId));
                lstParameter.Add(new MySqlParameter("_PartID", partId));
                lstParameter.Add(new MySqlParameter("_CustomerID", customerId));
                lstParameter.Add(new MySqlParameter("_Date", date));
                lstParameter.Add(new MySqlParameter("_DOInvoiceNo", DOInvoiceNo));
                lstParameter.Add(new MySqlParameter("_Recd", recd));
                lstParameter.Add(new MySqlParameter("_LSold", lSold));
                lstParameter.Add(new MySqlParameter("_GOnHand", gOnHand));
                lstParameter.Add(new MySqlParameter("_Price", price));
                lstParameter.Add(new MySqlParameter("_RSold", rSold));
                lstParameter.Add(new MySqlParameter("_IMOnHand", imOnHand));
                lstParameter.Add(new MySqlParameter("_OEMRecd", oemRecd));
                lstParameter.Add(new MySqlParameter("_Price2", price2));
                lstParameter.Add(new MySqlParameter("_TotalAvailabel", totalAvailabel));
                lstParameter.Add(new MySqlParameter("_TotalDemand", totalDemand));
                lstParameter.Add(new MySqlParameter("_UserID", userId));

                lstParameter.Add(new MySqlParameter("_Detail", detail));

                sqlHelper.executenonquery(lstParameter, "UpdatePartInventory");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void deletePartInventoryById(int partInventoryId, int userId)
        {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_PartInventoryID", partInventoryId));
                lstParameter.Add(new MySqlParameter("_UserID", userId));

                sqlHelper.executenonquery(lstParameter, "DeletePartInventory");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    public class PartInventory {
        public int partInventoryId { get; set; }
        public int partId { get; set; }
        public DateTime regDate { get; set; }
        public string DOInvoiceNo { get; set; }
        public int customerId { get; set; }
        public string customerName { get; set; }

        public int incomeGOnHand { get; set; }

        public int recd { get; set; }
        public int lSold { get; set; }
        public int gOnHand { get; set; }
        public decimal price { get; set; }
        public int rSold { get; set; }
        public int imOnHand { get; set; }
        public int oemRecd { get; set; }
        public decimal price2 { get; set; }
        public int totalAvailabel { get; set; }
        public int totalDemand { get; set; }

        public string detail { get; set; }
    }
}
