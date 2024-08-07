using backend.Dtos.Account;
using backend.Helpers;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IAccountRepo _accountRepo;

    public AccountController(
        UserManager<AppUser> userManager,
        ITokenService tokenService,
        SignInManager<AppUser> signInManager,
        IAccountRepo accountRepo
    )
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
        _accountRepo = accountRepo;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = _userManager.Users.FirstOrDefault(x => x.UserName == loginDto.UserName);

        if (user == null)
            return Unauthorized("Invalid Username.");

        var res = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        if (!res.Succeeded)
            return Unauthorized("Invalid Username or Password");

#pragma warning disable CS8601 // Possible null reference assignment.
        return Ok(
            new NewUserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
            }
        );
#pragma warning restore CS8601 // Possible null reference assignment.
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var appUser = new AppUser
            {
                FirstName = registerDto.FirstName,
                MiddleName = registerDto.MiddleName,
                LastName = registerDto.LastName,
                ProfilePhoto = registerDto.ProfilePhoto,
                Birthdate = registerDto.Birthdate,
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };

            var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);
            
            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

                if (roleResult.Succeeded)
                {
                    return Ok(
                        new NewUserDto
                        {
                            UserName = appUser.UserName,
                            Email = appUser.Email,
                            Token = _tokenService.CreateToken(appUser),
                        }
                    );
                }
                else
                    return StatusCode(500, roleResult.Errors);
            }
            else
                return StatusCode(500, createdUser.Errors);

        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }

    [Authorize]
    [HttpGet("users")]
    public async Task<IActionResult> GetUsers([FromQuery] QueryUser query)
    {
        var users = await _accountRepo.QueryAllUsersAsync(query);

        var userList = users.Select(s => s.toUserCardDto()).ToList();

        return Ok(userList);
    }
}
