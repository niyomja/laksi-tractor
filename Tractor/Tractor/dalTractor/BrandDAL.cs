using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MySql.Data.MySqlClient;
using System.Data;

namespace dalTractor
{
    public class BrandDAL
    {
        public static void create(string brandname, string description, int userId) {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_BrandName", brandname));
                lstParameter.Add(new MySqlParameter("_Description", description));
                lstParameter.Add(new MySqlParameter("_UserID", userId));

                sqlHelper.executenonquery(lstParameter, "CreateBrand");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<Brand> getBrands()
        {
            try
            {
                SQLHelper dbhelper = new SQLHelper();

                List<MySqlParameter> lstParameter = new List<MySqlParameter>();

                var resultSet = dbhelper.executeSP<DataSet>(lstParameter, "SelectAllBrand");

                List<Brand> brands = new List<Brand>();
                foreach (DataRow drow in resultSet.Tables[0].Rows)
                {
                    Brand brand = new Brand();
                    brand.BrandID = Convert.ToInt32(drow["brandId"].ToString());
                    brand.Brandname = drow["brandname"].ToString();
                    brand.Description = drow["description"].ToString();

                    brands.Add(brand);
                }

                return brands;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    public class Brand
    {
        public int BrandID { get; set; }
        public string Brandname { get; set; }
        public string Description { get; set; }
    }
}
