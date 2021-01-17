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
                if (string.IsNullOrEmpty(model.FullName) | string.IsNullOrEmpty(model.School) | string.IsNullOrEmpty(model.UserName) | string.IsNullOrEmpty(model.Password))
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

        [HttpPost("InsertScore")]
        public IActionResult InsertScore([FromBody] ScoreModel model)
        {
            try
            {
                if (model.RegisterId == 0 | model.Score == 0)
                {
                    return BadRequest(new ArgumentNullException());
                }

                return Ok(_RegistrationBL.InsertScore(model));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.GetBaseException());
            }
        }

        [HttpPost("GetPreviousScore")]
        public IActionResult GetPreviousScore([FromBody] ScoreModel model)
        {
            try
            {
                if (model.RegisterId == 0)
                {
                    return BadRequest(new ArgumentNullException());
                }

                return Ok(_RegistrationBL.GetPreviousScore(model.RegisterId));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.GetBaseException());
            }
        }


    }
}