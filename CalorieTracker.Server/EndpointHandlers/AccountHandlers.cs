using System.Security.Claims;
using CalorieTracker.Server.Models.Account;
using CalorieTracker.Server.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace CalorieTracker.Server.EndpointHandlers;

public static class AccountHandlers
{
    public static async Task<Results<Ok<string>, BadRequest<IdentityResult>, ProblemHttpResult>> RegisterAsync(
        IAccountService accountService,
        RegisterDto registerUserDto)
    {
        try
        {
            var(identityResult, userId) = await accountService.RegisterUserAsync(registerUserDto);

            if (!identityResult.Succeeded)
            {
                return TypedResults.BadRequest(identityResult);
            }

            return TypedResults.Ok(userId);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(ex.Message);
        }
    }

    public static async Task<Results<Ok<AccountDto>, BadRequest<SignInResult>, ProblemHttpResult>> LoginAsync(
        IAccountService accountService,
        LoginDto loginDto)
    {
        try
        {
            var (signInResult, user) = await accountService.LoginUserAsync(loginDto);

            if (!signInResult.Succeeded)
            {
                return TypedResults.BadRequest(signInResult);
            }

            return TypedResults.Ok(new AccountDto
            {
                UserId = user!.UserId,
                UserName = user.UserName,
                Email = user.Email
            });

        }
        catch (Exception ex)
        {
            return TypedResults.Problem(ex.Message);
        }
    }

    public static async Task<Ok> LogoutAsync(
        IAccountService accountService)
    {
        await accountService.LogoutUserAsync();

        return TypedResults.Ok();
    }

    public static async Task<Ok<AccountDto>> GetUserDetails(
        IAccountService accountService,
        ClaimsPrincipal claimsPrincipal)
    {
        var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

        var user = await accountService.GetUserDetailsByIdAsync(userId!);

        return TypedResults.Ok(new AccountDto
        {
            UserId = user.UserId,
            UserName = user.UserName,
            Email = user.Email
        });
    }

    public static async Task<Results<Ok<AccountDto>,BadRequest<string>>> UpdateAccount(
        ClaimsPrincipal claimsPrincipal,
        IAccountService accountService,
        [FromBody]UpdateAccountDto updateAccountDto)
    {
        var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

        try
        {
            var user = await accountService.UpdateAccountAsync(updateAccountDto, userId!);

            return TypedResults.Ok(new AccountDto
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email
            });
        }
        catch (System.Exception)
        {
            return TypedResults.BadRequest("Error updating user");
        }
    }
}
