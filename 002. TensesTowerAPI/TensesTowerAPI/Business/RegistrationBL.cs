using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TensesTowerAPI.Repository;
using TensesTowerAPI.Models;

namespace TensesTowerAPI.Business
{
    public class RegistrationBL
    {
        private StudentRepo _StudentRepo;

        public RegistrationBL(StudentRepo StudentRepo)
        {
            _StudentRepo = StudentRepo;
        }

        public bool NewStudentRegistration(RegistrationModel model)
        {
            return true;
        }
    }
}
