﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TensesTowerAPI.Models;
using TensesTowerAPI.Business;

namespace TensesTowerAPI.Controllers
{
    public class LoginController : BaseController
    {
        private LoginBL _LoginBL;

        public LoginController(LoginBL LoginBL)
        {
            _LoginBL = LoginBL;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.LoginID) | string.IsNullOrEmpty(model.LoginPassword))
                {
                    return BadRequest(new ArgumentNullException());
                }

                return Ok(_LoginBL.Login(model.LoginID, model.LoginPassword));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.GetBaseException());
            }
        }
    }
}