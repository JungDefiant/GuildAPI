using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildAPI.Models;
using GuildAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GuildAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost, Route("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            ApplicationUser user = new ApplicationUser()
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                UserName = registerDTO.Email
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Ok();
            }
            
            return BadRequest("Invalid Registration");
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, false, false);

            if(result.Succeeded)
            {
                return Ok("Logged in");
            }

            return BadRequest("Invalid attempt");
        }
    }
}
