﻿using Microsoft.AspNetCore.Mvc;
using RestaurantAPI3.Models;
using RestaurantAPI3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI3.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody]RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }
    }
}
