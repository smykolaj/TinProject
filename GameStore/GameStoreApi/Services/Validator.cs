using System.Text.RegularExpressions;
using GameStore.DTOs;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GameStore.Services;

public partial class Validator(ApplicationDbContext context)
{
    public async Task<List<string>> ValidateUser(CreateEditUserDTO user)
    {
        var errors = new List<string>();
        if (user.FirstName.IsNullOrEmpty())
            errors.Add("empty_f_name");

        if (user.LastName.IsNullOrEmpty())
            errors.Add("empty_l_name");
        
        if (user.BirthDate.AddDays(1) > DateTime.Today)
            errors.Add("future_birthday");

        if (user.BirthDate.Year < 1900)
            errors.Add("past_birthday");

        if (user.Email.IsNullOrEmpty())
            errors.Add("empty_email");
        else if (!EmailRegex().IsMatch(user.Email))
            errors.Add("format_email");
        else
            if (await context.Users.AnyAsync(u => u.Email.Equals(user.Email)))
                errors.Add("inUse_email");

        if (!LengthRegex().IsMatch(user.Password))
            errors.Add("length_password");


        if (!UppercaseRegex().IsMatch(user.Password))
            errors.Add("uppercase_password");
        
        if (!LowercaseRegex().IsMatch(user.Password))
            errors.Add("lowercase_password");
        
        if (!DigitRegex().IsMatch(user.Password))
            errors.Add("digit_password");
        
        if (!SymbolRegex().IsMatch(user.Password))
            errors.Add("symbol_password");
        
        if (user.Password != user.RepeatPassword)
            errors.Add("repeat_password");
        
        if (user.Gender.IsNullOrEmpty())
            errors.Add("empty_gender");

        return errors;
    }

    public async Task<Dictionary<string, string>> ValidateGame(CreateEditGameDTO game)
    {
        return new Dictionary<string, string>();
    }

    public async Task<Dictionary<string, string>> ValidatePurchase(CreateEditPurchaseDTO purchase)
    {
        return new Dictionary<string, string>();
    }

    [GeneratedRegex(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    private static partial Regex EmailRegex();

    [GeneratedRegex("[A-Z]")]
    private static partial Regex UppercaseRegex();

    [GeneratedRegex(@"[a-z]")]
    private static partial Regex LowercaseRegex();

    [GeneratedRegex(@"\d")]
    private static partial Regex DigitRegex();

    [GeneratedRegex(@"\W")]
    private static partial Regex SymbolRegex();

    [GeneratedRegex("^.{8,}$")]
    private static partial Regex LengthRegex();
}