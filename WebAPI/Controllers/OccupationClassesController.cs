﻿using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationClassesController : ControllerBase
    {
        IOccupationClassService _occupationClassService;

        public OccupationClassesController(IOccupationClassService occupationClassService)
        {
            _occupationClassService = occupationClassService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _occupationClassService.GetListAsync();
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateOccupationClassRequest createOccupationClassRequest)
        {
            var result = await _occupationClassService.AddAsync(createOccupationClassRequest);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateOccupationClassRequest updateOccupationClassRequest)
        {
            var result = await _occupationClassService.UpdateAsync(updateOccupationClassRequest);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteOccupationClassRequest deleteOccupationClassRequest)
        {
            var result = await _occupationClassService.DeleteAsync(deleteOccupationClassRequest);
            return Ok(result);
        }
    }
}