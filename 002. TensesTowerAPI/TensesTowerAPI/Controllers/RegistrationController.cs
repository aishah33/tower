using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TensesTowerAPI.Models;
using TensesTowerAPI.Business;

namespace TensesTowerAPI.Controllers
{
    public class RegistrationController : BaseController
    {
        private RegistrationBL _RegistrationBL;

        public RegistrationController(RegistrationBL RegistrationBL)
        {
            _RegistrationBL = RegistrationBL;
        }

        [HttpPost("NewStudentRegistration")]
        public IActionResult NewStudentRegistration([FromBody] RegistrationModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.FullName) | string.IsNullOrEmpty(model.SchoolName) | string.IsNullOrEmpty(model.UserName) | string.IsNullOrEmpty(model.Password))
                {
                    return BadRequest(new ArgumentNullException());
                }

                return Ok(_RegistrationBL.NewStudentRegistration(model));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.GetBaseException());
            }
        }
    }
}