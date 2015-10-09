using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dalTractor;

namespace appTractor.Model
{
    public class UserModel : IModelBase
    {
        private User user;

        public User checkLogin(string username, string password)
        {
            var user = UserDAL.getUser(username, password);

            return user;
        }

        public void updateLastAccess(int userId)
        {
            UserDAL.updateLastAccess(userId);
        }

        public List<User> getAllUsers()
        {
            return UserDAL.getAllUsers();
        }

        public void delete(int userId, int updateUserId)
        {
            UserDAL.delete(userId, updateUserId);
        }

        public void update(User user, int updateUserId)
        {
            UserDAL.update(user.UserID, user.FirstName, user.LastName, user.Username, user.Password, user.Email, user.Mobile, user.Status, user.RoleAdmin, updateUserId);
        }

        public bool add(User user, int createUserId)
        {
            this.user = user;
            if (invalid())
            {
                UserDAL.add(user.FirstName, user.LastName, user.Username, user.Password, user.Email, user.Mobile, user.Status, user.RoleAdmin, createUserId);
                return true;
            }
            else {
                return false;
            }
        }

        private bool invalid()
        {
            return (!String.IsNullOrEmpty(user.Username) && !String.IsNullOrEmpty(user.Password));
        }
    }
}
