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
        public IActionResult Login(LoginDto model)
        {
            var userAuth = _accountService.Login(model);
            
            return Ok(userAuth);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterDto model)
        {
            var user = _accountService.Register(model);

            return Created(new Uri(Request.GetDisplayUrl()), user);
        }

        [HttpPatch]
        [Route("forgotpassword")]
        public void ForgotPassword([FromBody] string email)
        {
            _accountService.ForgotPassword(email);
        }

        //[HttpPatch]
        //[Route("resetpassword")]
        //public void ResetPassword(ResetPasswordModel model)
        //{
        //    _accountsService.ResetPassword(model.Password, model.ResetKey, Localization.Base_EnLanguageSign);
        //}
    }
}
