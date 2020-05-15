using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TensesTowerAPI.Repository;
using TensesTowerAPI.Models;

namespace TensesTowerAPI.Business
{
    public class LoginBL
    {
        public LoginBL()
        {
        }

        public LoginModel Login(string LoginID, string Password)
        {
            LoginModel Login = new LoginModel();

            try
            {
                Login = null;
            }
            catch (Exception)
            {
                Login = null;
            }

            return Login;
        }
    }
}
