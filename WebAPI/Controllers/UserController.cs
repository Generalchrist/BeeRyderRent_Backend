using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        IUserService _userManager;
        public UserController(IUserService userManager) {
            _userManager = userManager;
        }

        [HttpGet("getclaims")]
        public IActionResult GetClaims(UserDTO user) {
            var result = _userManager.GetClaims(user);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(UserDTO user) {
            var result = _userManager.Add(user);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("changepassword")]
        public IActionResult ChangePassword(ChangePasswordDto user) {
            var result = _userManager.ChangePassword(user);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserDTO user) {
            var result = _userManager.Update(user);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getuser")]
        public IActionResult GetUser(int id) {
            var result = _userManager.GetUser(id);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbymail")]
        public IActionResult GetByMail(string email) {
            var result = _userManager.GetByMail(email);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

