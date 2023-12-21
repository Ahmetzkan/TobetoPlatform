﻿using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountSessionsController : ControllerBase
    {
        IAccountSessionService _accountSessionService;

        public AccountSessionsController(IAccountSessionService accountSessionService)
        {
            _accountSessionService = accountSessionService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _accountSessionService.GetListAsync();
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateAccountSessionRequest createAccountSessionRequest)
        {
            var result = await _accountSessionService.AddAsync(createAccountSessionRequest);
            return Ok(result);
        }


        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountSessionRequest updateAccountSessionRequest)
        {
            var result = await _accountSessionService.UpdateAsync(updateAccountSessionRequest);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountSessionRequest deleteAccountSessionRequest)
        {
            var result = await _accountSessionService.DeleteAsync(deleteAccountSessionRequest);
            return Ok(result);


        }
    }
}