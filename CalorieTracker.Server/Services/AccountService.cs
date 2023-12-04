using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models.Account;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Server.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<(IdentityResult, string?)> RegisterUserAsync(RegisterDto registerUserDto)
    {
        var user = new ApplicationUser
        {
            UserName = registerUserDto.Username,
            Email = registerUserDto.Email,
        };
        
        var result = await _userManager.CreateAsync(user, registerUserDto.Password);
        
        return  (result, user.Id);
    }

    public async Task<SignInResult> LoginUserAsync(LoginDto loginDto)
    {
        return await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, true, false);
    }

    public async Task<string> GetUserIdAsyncByUserName(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        return user.Id;
    }

    public async Task<AccountDto> GetUserDetailsByIdAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        return new AccountDto
        {
            UserId = user!.Id,
            UserName = user.UserName!,
            Email = user.Email!
        };
    }

    public async Task<AccountDto> GetUserDetailsByUserNameAsync(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);

        return new AccountDto
        {
            UserId = user!.Id,
            UserName = user.UserName!,
            Email = user.Email!
        };
    }

    public async Task<AccountDto> GetUserDetailsByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        return new AccountDto
        {
            UserId = user!.Id,
            UserName = user.UserName!,
            Email = user.Email!
        };
    }

    public async Task LogoutUserAsync()
    {
        await _signInManager.SignOutAsync();
    }
}