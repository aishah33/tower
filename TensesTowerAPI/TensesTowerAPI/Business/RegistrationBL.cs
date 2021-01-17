using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TensesTowerAPI.Repository;
using TensesTowerAPI.Models;
using System.Transactions;

namespace TensesTowerAPI.Business
{
    public class RegistrationBL
    {
        private StudentRepo _StudentRepo;
       
        public RegistrationBL(StudentRepo StudentRepo)
        {
            _StudentRepo = StudentRepo;
        }

        public ApiResponseModel NewStudentRegistration(RegistrationModel model)
        {
            ApiResponseModel Response = new ApiResponseModel();
            
            using (var Scope = new TransactionScope())
            {
                bool StudentExist = _StudentRepo.GetStudentByFullName(model.FullName.ToString().Trim().ToUpper()) == null ? false : true;
                bool UserNameExist = _StudentRepo.GetStudentByUserName(model.UserName.ToString().Trim()) == null ? false : true;
                bool InsertRegistration = (StudentExist == false && UserNameExist == false) ? _StudentRepo.InsertRegistration(model) : false;

                if (InsertRegistration == true)
                {
                    Response.Status = true;
                    Response.Message = "Succesful";

                    Scope.Complete();
                }
                else
                {
                    Response.Status = false;
                    Response.Message = StudentExist == true ? "Student already exist" : UserNameExist == true ? "UserName already exist" : InsertRegistration == false ? "Registration unsuccessful" : "Tenses Tower API Error";
                 }

                return Response;
            }
        }

        public bool InsertScore(ScoreModel model)
        {
           bool Insert = false;

            using (var Scope = new TransactionScope())
            {
                Insert = _StudentRepo.InsertScore(model);

                if (Insert == true)
                {
                    Scope.Complete();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public ScoreModel GetPreviousScore(int RegisterID)
        {
            return _StudentRepo.GetPreviousScore(RegisterID);
        }

    }
}
