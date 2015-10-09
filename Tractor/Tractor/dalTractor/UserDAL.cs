using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MySql.Data.MySqlClient;
using System.Data;

namespace dalTractor
{
    public class UserDAL
    {
        public static User getUser(string username, string password)
        {
            try
            {
                SQLHelper dbhelper = new SQLHelper();
               
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_Username", username));
                lstParameter.Add(new MySqlParameter("_Password", password));
               
                var resultSet = dbhelper.executeSP<DataSet>(lstParameter, "SelectUserByUsernamePassword");

                User user =new User();
                foreach (DataRow drow in resultSet.Tables[0].Rows)
                {
                    user.UserID = Convert.ToInt32(drow["userId"].ToString());
                    user.FirstName = drow["firstname"].ToString();
                    user.LastName = drow["lastname"].ToString();
                    user.Username = drow["username"].ToString();
                    user.Password = drow["password"].ToString();
                    user.Email = drow["email"].ToString();
                    user.Mobile = drow["mobile"].ToString();
                    user.Status = Convert.ToInt32(drow["status"].ToString());
                    user.LastAccess = drow["lastaccess"].ToString();
                    user.RoleAdmin = Convert.ToInt32(drow["role_admin"].ToString());
                    
                }

                return user;
            }
            catch (Exception e) {
                throw e;
            }
        }

        public static void updateLastAccess(int userId)
        {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_UserID", userId));
                sqlHelper.executenonquery(lstParameter, "UpdateUserLastAccess");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<User> getAllUsers()
        {
            try
            {
                SQLHelper dbhelper = new SQLHelper();

                List<MySqlParameter> lstParameter = new List<MySqlParameter>();

                var resultSet = dbhelper.executeSP<DataSet>(lstParameter, "SelectAllUsers");

                var users = new List<User>();
                foreach (DataRow drow in resultSet.Tables[0].Rows)
                {
                    User user = new User();
                    user.UserID = Convert.ToInt32(drow["userId"].ToString());
                    user.FirstName = drow["firstname"].ToString();
                    user.LastName = drow["lastname"].ToString();
                    user.Username = drow["username"].ToString();
                    user.Password = drow["password"].ToString();
                    user.Email = drow["email"].ToString();
                    user.Mobile = drow["mobile"].ToString();
                    user.Status = Convert.ToInt32(drow["status"].ToString());
                    user.RoleAdmin = Convert.ToInt32(drow["role_admin"].ToString());
                    user.LastAccess = drow["lastaccess"].ToString();
                    users.Add(user);
                }

                return users;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void delete(int userId, int updateUserId)
        {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_UserID", userId));
                lstParameter.Add(new MySqlParameter("_UpdateUserID", updateUserId));

                sqlHelper.executenonquery(lstParameter, "DeleteUser");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void update(int UserID, string FirstName, string LastName, string Username, string Password, string Email, string Mobile, int Status, int RoleAdmin, int updateUserId)
        {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_UserID", UserID));
                lstParameter.Add(new MySqlParameter("_FirstName", FirstName));
                lstParameter.Add(new MySqlParameter("_LastName", LastName));
                lstParameter.Add(new MySqlParameter("_Username", Username));
                lstParameter.Add(new MySqlParameter("_Password", Password));
                lstParameter.Add(new MySqlParameter("_Email", Email));
                lstParameter.Add(new MySqlParameter("_Mobile", Mobile));
                lstParameter.Add(new MySqlParameter("_Status", Status));
                lstParameter.Add(new MySqlParameter("_RoleAdmin", RoleAdmin));
                lstParameter.Add(new MySqlParameter("_UpdateUserID", updateUserId));

                sqlHelper.executenonquery(lstParameter, "UpdateUser");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void add(string FirstName, string LastName, string Username, string Password, string Email, string Mobile, int Status, int RoleAdmin, int createUserId)
        {
            try
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("_FirstName", FirstName));
                lstParameter.Add(new MySqlParameter("_LastName", LastName));
                lstParameter.Add(new MySqlParameter("_Username", Username));
                lstParameter.Add(new MySqlParameter("_Password", Password));
                lstParameter.Add(new MySqlParameter("_Email", Email));
                lstParameter.Add(new MySqlParameter("_Mobile", Mobile));
                lstParameter.Add(new MySqlParameter("_Status", Status));
                lstParameter.Add(new MySqlParameter("_RoleAdmin", RoleAdmin));
                lstParameter.Add(new MySqlParameter("_CreateUserID", createUserId));

                sqlHelper.executenonquery(lstParameter, "CreateUser");
            }
            catch (Exception e)
            {
                throw e;
            } 
        }
    }

    public class User {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public string LastAccess { get; set; }
        public int RoleAdmin { get; set; }
    }
}
