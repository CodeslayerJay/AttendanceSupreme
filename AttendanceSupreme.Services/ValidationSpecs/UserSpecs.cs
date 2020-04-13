using AttendanceSupreme.Engine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceSupreme.Services.ValidationSpecs
{
    public static class UserSpecs
    {
       
        public static ValidationResult ValidateUser(User user)
        {
            var result = new ValidationResult();

            if (user == null)
                result.AddError("User cannot be null.");

            if (String.IsNullOrEmpty(user.FirstName))
                result.AddError("First name is required.");

            if (String.IsNullOrEmpty(user.LastName))
                result.AddError("Last name is required");

            var pwValidationResult = ValidatePassword(user.Password);

            if (pwValidationResult.IsValid == false)
                result.AddError(pwValidationResult.Errors);

            if (user.LastFourSSN < 4)
                result.AddError("Last four SSN required and must be 4 characters long.");



            return result;
        }


        /// <summary>
        /// Validate password based on configuration defined in Settings.cs
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static ValidationResult ValidatePassword(string password)
        {
            var result = new ValidationResult();

            if (String.IsNullOrEmpty(password))
                result.AddError("Password is required.");

            if(password.Length < Settings.PasswordMinLength)
                result.AddError($"Password must be" + Settings.PasswordMinLength + " long");



            var uppercaseLetters = 0;
            var lowercaseLetters = 0;
            var letters = 0;
            var numbers = 0;
            var whitespaceCount = 0;
            var symbols = 0;
            
            foreach(var ch in password)
            {
                if (char.IsWhiteSpace(ch)) whitespaceCount++;
                if (char.IsLetter(ch)) letters++;
                if (char.IsDigit(ch)) numbers++;
                if (char.IsSymbol(ch)) symbols++;
                if (char.IsPunctuation(ch)) symbols++;
                if (char.IsUpper(ch)) uppercaseLetters++;
                if (char.IsLower(ch)) lowercaseLetters++;
            }

            if (Settings.PasswordIsUppercaseRequired && uppercaseLetters < Settings.PasswordMinRequiredUppercaseLetters)
                result.AddError($"Password must include at least " + Settings.PasswordMinRequiredUppercaseLetters + " letters.");

            if(Settings.PasswordIsLowercaseRequired && lowercaseLetters < Settings.PasswordMinRequiredLowercaseLetters)
                result.AddError($"Password must include at least " + Settings.PasswordMinRequiredLowercaseLetters + " letters.");

            if (Settings.PasswordIsUniqueCharsRequired && symbols == 0)
                result.AddError("Password must include unique symbols.");

            if (Settings.PasswordIsNumberRequired && numbers == 0)
                result.AddError("Password must include numbers.");

            if (whitespaceCount > 0)
                result.AddError("Password cannot include whitespaces.");

            return result;
        }


       
    }
}
