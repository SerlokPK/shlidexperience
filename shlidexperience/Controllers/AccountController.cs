﻿using Common;
using DtoModels.Account.Request;
using Interfaces.Services;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace shlidexperience.Controllers
{
    [Route("api/account")]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        public AccountController(IOptions<AppSettings> options, IAccountService accountService) : base(options)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
            var userAuth = _accountService.Login(model);
            
            return Ok(userAuth);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterModel model)
        {
            var user = _accountService.Register(model);

            return Created(new Uri(Request.GetDisplayUrl()), user);
        }

        [HttpPost]
        [Route("forgotpassword")]
        public void ForgotPassword([FromForm] string email)
        {
            _accountService.ForgotPassword(email);
        }

        [HttpPost]
        [Route("resetpassword")]
        public void ResetPassword(ResetPasswordModel model)
        {
            _accountService.ResetPassword(model);
        }
    }
}
