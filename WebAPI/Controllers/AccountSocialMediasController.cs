﻿using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountSocialMediasController : ControllerBase
{
    IAccountSocialMediaService _accountSocialMediaService;

    public AccountSocialMediasController(IAccountSocialMediaService examService)
    {
        _accountSocialMediaService = examService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _accountSocialMediaService.GetListAsync();
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountSocialMediaRequest createAccountSocialMediaRequest)
    {
        var result = await _accountSocialMediaService.AddAsync(createAccountSocialMediaRequest);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountSocialMediaRequest updateAccountSocialMediaRequest)
    {
        var result = await _accountSocialMediaService.UpdateAsync(updateAccountSocialMediaRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountSocialMediaRequest deleteAccountSocialMediaRequest)
    {
        var result = await _accountSocialMediaService.DeleteAsync(deleteAccountSocialMediaRequest);
        return Ok(result);
    }
}