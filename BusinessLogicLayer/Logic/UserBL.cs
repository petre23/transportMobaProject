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
    }
}
