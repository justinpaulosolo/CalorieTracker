using CalorieTracker.Server.Models.Account;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Server.Services;

public interface IAccountService
{
    public Task<(IdentityResult, string?)> RegisterUserAsync(RegisterDto registerUserDto);
    public Task<(SignInResult, AccountDto?)> LoginUserAsync(LoginDto loginDto);
    public Task<string> GetUserIdAsyncByUserName(string userName);
    public Task<AccountDto> GetUserDetailsByIdAsync(string userId);
    public Task<AccountDto> GetUserDetailsByUserNameAsync(string userName);
    public Task<AccountDto> GetUserDetailsByEmailAsync(string email);
    public Task LogoutUserAsync();
}