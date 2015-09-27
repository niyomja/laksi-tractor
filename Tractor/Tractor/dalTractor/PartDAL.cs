using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MySql.Data.MySqlClient;
using System.Data;

namespace dalTractor
{
    public class PartDAL 
    {
        public static int create(int brandId, string partNo, string partName, string model, decimal gsp, decimal imsp, string locG, string locIM, string comment, int userId)
        {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_BrandID", brandId));
                lstParameter.Add(new MySqlParameter("_PartNo", partNo));
                lstParameter.Add(new MySqlParameter("_PartName", partName));
                lstParameter.Add(new MySqlParameter("_Model", model));
                lstParameter.Add(new MySqlParameter("_GSP", gsp));
                lstParameter.Add(new MySqlParameter("_IMSP", imsp));
                lstParameter.Add(new MySqlParameter("_LocG", locG));
                lstParameter.Add(new MySqlParameter("_LocIM", locIM));
                lstParameter.Add(new MySqlParameter("_Comment", comment));
                lstParameter.Add(new MySqlParameter("_UserID", userId));

                sqlHelper.executenonquery(lstParameter, "CreatePart");

                return sqlHelper.lastInsertId();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<Part> getPartsByBrandId(int brandId)
        {
            try
            {
                SQLHelper dbhelper = new SQLHelper();

                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_BrandID", brandId));

                var resultSet = dbhelper.executeSP<DataSet>(lstParameter, "SelectPartByBrandId");

                List<Part> parts = new List<Part>();
                foreach (DataRow drow in resultSet.Tables[0].Rows)
                {
                    Part part = new Part();
                   
                    part.PartID = Convert.ToInt32(drow["partId"].ToString());
                    part.BrandID = Convert.ToInt32(drow["brandId"].ToString());
                    part.PartNo = drow["partno"].ToString();
                    part.PartName = drow["partname"].ToString();
                    part.Model = drow["model"].ToString();
                    part.GSP = Convert.ToDecimal(drow["gsp"].ToString());
                    part.IMSP = Convert.ToDecimal(drow["imsp"].ToString());
                    part.Status = Convert.ToInt32(drow["status"].ToString());
                    part.LocG = drow["locG"].ToString();
                    part.LocIM = drow["locIM"].ToString();
                    part.Comment = drow["comment"].ToString();
                    part.is_new = false;

                    parts.Add(part);
                }

                return parts;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<Part> getPartsByBrandIdPartNo(int brandId, string partNo)
        {
            try
            {
                SQLHelper dbhelper = new SQLHelper();

                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_BrandID", brandId));
                lstParameter.Add(new MySqlParameter("_PartNo", partNo));

                var resultSet = dbhelper.executeSP<DataSet>(lstParameter, "SelectPartByBrandIdPartNo");

                List<Part> parts = new List<Part>();
                foreach (DataRow drow in resultSet.Tables[0].Rows)
                {
                    Part part = new Part();

                    part.PartID = Convert.ToInt32(drow["partId"].ToString());
                    part.BrandID = Convert.ToInt32(drow["brandId"].ToString());
                    part.PartNo = drow["partno"].ToString();
                    part.PartName = drow["partname"].ToString();
                    part.Model = drow["model"].ToString();
                    part.GSP = Convert.ToDecimal(drow["gsp"].ToString());
                    part.IMSP = Convert.ToDecimal(drow["imsp"].ToString());
                    part.Status = Convert.ToInt32(drow["status"].ToString());
                    part.LocG = drow["locG"].ToString();
                    part.LocIM = drow["locIM"].ToString();
                    part.Comment = drow["comment"].ToString();
                    part.is_new = false;

                    parts.Add(part);
                }

                return parts;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void deletePartById(int partId, int userId)
        {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_PartID", partId));
                lstParameter.Add(new MySqlParameter("_UserID", userId));

                sqlHelper.executenonquery(lstParameter, "DeletePart");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void update(int partId, int brandId, string partNo, string partName, string model, decimal gsp, decimal imsp, string locG, string locIM, string comment, int userId)
        {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_PartID", partId));
                lstParameter.Add(new MySqlParameter("_BrandID", brandId));
                lstParameter.Add(new MySqlParameter("_PartNo", partNo));
                lstParameter.Add(new MySqlParameter("_PartName", partName));
                lstParameter.Add(new MySqlParameter("_Model", model));
                lstParameter.Add(new MySqlParameter("_GSP", gsp));
                lstParameter.Add(new MySqlParameter("_IMSP", imsp));
                lstParameter.Add(new MySqlParameter("_LocG", locG));
                lstParameter.Add(new MySqlParameter("_LocIM", locIM));
                lstParameter.Add(new MySqlParameter("_Comment", comment));
                lstParameter.Add(new MySqlParameter("_UserID", userId));

                sqlHelper.executenonquery(lstParameter, "UpdatePart");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    public class Part {
        public int PartID { get;set; }
        public int BrandID { get; set; }
        public string PartNo { get; set; }
        public string PartName { get; set; }
        public string Model { get; set; }
        public decimal GSP { get; set; }
        public decimal IMSP { get; set; }
        public string LocG { get; set; }
        public string LocIM { get; set; }
        public string Comment { get; set; }
        public int Status { get; set; }

        public bool is_new { get; set; } 
    }
}
