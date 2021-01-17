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
        private StudentRepo _StudentRepo;

        public LoginBL(StudentRepo StudentRepo)
        {
            _StudentRepo = StudentRepo;
        }

        public RegistrationModel Login(string UserName, string Password)
        {
            RegistrationModel Login = new RegistrationModel();

            try
            {
                Login = _StudentRepo.GetStudentByUserNamePassword(UserName, Password);
            }
            catch (Exception) 
            {
                Login = null;
            }

            return Login;
        }
    }
}
