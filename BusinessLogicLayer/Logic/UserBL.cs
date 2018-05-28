using BusinessLogicLayer.Helpers;
using DataLayer.PersistanceLayer;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Logic
{
    public class UserBL
    {
        UserRepository _userRepositoty = new UserRepository();
        LoginHelper _loginHelper = new LoginHelper();

        public User Login(User user)
        {
            if (user != null && !string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
            {
                user.Password = _loginHelper.HashPasswordToMD5(user.Password);
                return _userRepositoty.Login(user);
            }
            return null;
        }

        public List<User> GetUsers()
        {
            return _userRepositoty.GetUsers();
        }

        public User GetUser(Guid userId)
        {
            return _userRepositoty.GetUser(userId);
        }

        public Guid SaveUser(User user)
        {
            var hasSamePassword = false;
            if (user.Id != Guid.Empty)
            {
                var userOldPass = _userRepositoty.GetUser(user.Id).Password;
                if (userOldPass == user.Password)
                    hasSamePassword = true;
            }
            user.Password = hasSamePassword ? user.Password : _loginHelper.HashPasswordToMD5(user.Password);
            return _userRepositoty.SaveUser(user);
        }
        public void DeleteUser(Guid userId)
        {
            _userRepositoty.DeleteUser(userId);
        }

    }
}
