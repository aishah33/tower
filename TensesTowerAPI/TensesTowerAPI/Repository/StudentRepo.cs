using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using TensesTowerAPI.Models;
using Dapper;

namespace TensesTowerAPI.Repository
{
    public class StudentRepo
    {
        private IConfiguration _Configuration;

        public StudentRepo(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }

        public RegistrationModel GetStudentByFullName(string FullName)
        {
            string connStr = _Configuration.GetConnectionString("TENSESTOWER");

            RegistrationModel Registration = new RegistrationModel();

            try
            {
                string sqlstr = @"SELECT * FROM register WHERE FullName = @FullName";

                using (var conn = new MySqlConnection(connStr))
                {
                    Registration = conn.Query<RegistrationModel>(sqlstr, new { FullName = FullName }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                Registration = null;
            }

            return Registration;
        }

        public RegistrationModel GetStudentByUserName(string UserName)
        {
            string connStr = _Configuration.GetConnectionString("TENSESTOWER");

            RegistrationModel Registration = new RegistrationModel();

            try
            {
                string sqlstr = @"SELECT * FROM register WHERE UserName = @UserName";

                using (var conn = new MySqlConnection(connStr))
                {
                    Registration = conn.Query<RegistrationModel>(sqlstr, new { UserName = UserName }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                Registration = null;
            }

            return Registration;
        }

        public RegistrationModel GetStudentByUserNamePassword(string UserName, string Password)
        {
            string connStr = _Configuration.GetConnectionString("TENSESTOWER");

            RegistrationModel Registration = new RegistrationModel();

            try
            {
                string sqlstr = @"SELECT * FROM register WHERE UserName = @UserName AND Password = @Password";

                using (var conn = new MySqlConnection(connStr))
                {
                    Registration = conn.Query<RegistrationModel>(sqlstr, new { UserName = UserName, Password = Password}).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                Registration = null;
            }

            return Registration;
        }

        public bool InsertRegistration(RegistrationModel Registration)
        {
            string connStr = _Configuration.GetConnectionString("TENSESTOWER");
            
            bool Result = false;

            try
            {
                string sqlstr = @"INSERT INTO register (FullName, UserName, Password, School) VALUES (@FullName, @UserName, @Password, @School)";

                using (var conn = new MySqlConnection(connStr))
                {
                    Result = conn.Execute(sqlstr, new
                    {
                        FullName = Registration.FullName.ToString().Trim().ToUpper(),
                        UserName = Registration.UserName.ToString().Trim(),
                        Password = Registration.Password.ToString().Trim(),
                        School = Registration.School.ToString().Trim().ToUpper()
                    }) > 0;
                }
            }
            catch (Exception)
            {
                Result = false;
            }

            return Result;
        }

        public bool InsertScore(ScoreModel Score)
        {
            string connStr = _Configuration.GetConnectionString("TENSESTOWER");

            bool Result = false;

            try
            {
                string sqlstr = @"INSERT INTO score (RegisterId, Score) VALUES (@RegisterId, @Score)";

                using (var conn = new MySqlConnection(connStr))

                {
                    Result = conn.Execute(sqlstr, new
                    {
                        RegisterId = Score.RegisterId,
                        Score = Score.Score
                    }) > 0;
                }
            }
            catch (Exception)
            {
                Result = false;
            }

            return Result;
        }

        public ScoreModel GetPreviousScore(int RegisterID)
        {
            string connStr = _Configuration.GetConnectionString("TENSESTOWER");

            ScoreModel Score = new ScoreModel();

            try
            {
                string sqlstr = @"SELECT * FROM score WHERE RegisterId = @RegisterId ORDER BY Id DESC LIMIT 1,1";

                using (var conn = new MySqlConnection(connStr))
                {
                    Score = conn.Query<ScoreModel>(sqlstr, new { RegisterId = RegisterID }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                Score = null;
            }

            return Score;
        }


    }
}
