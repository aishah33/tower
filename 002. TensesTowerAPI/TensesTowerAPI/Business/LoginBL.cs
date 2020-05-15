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
        private LoginRepo _LoginRepo;

        public LoginBL(LoginRepo LoginRepo)
        {
            _LoginRepo = LoginRepo;
        }

        public LoginModel Login(string LoginID, string Password)
        {
            LoginModel Login = new LoginModel();

            try
            {
                Login.LoginID = "SOMES";
                Login.LoginPassword = "1234";
            }
            catch (Exception)
            {
                Login = null;
            }

            return Login;
        }
    }
}
