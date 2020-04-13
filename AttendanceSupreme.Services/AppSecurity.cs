﻿using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceSupreme.Services
{
    public class AppSecurity
    {
        

        //public static JsonWebToken GenerateToken(int userId)
        //{
        //    //Add Claims
        //    var claims = new[]
        //    {
        //        new Claim(JwtRegisteredClaimNames.UniqueName, "data"),
        //        new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //    };

        //    var creds = new SigningCredentials(TokenConfig.GetKey(), SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        TokenConfig.ValidIssuer,
        //        TokenConfig.ValidAudience,
        //        claims,
        //        expires: TokenConfig.Expires,
        //        signingCredentials: creds);

        //    var accessToken = new JsonWebToken()
        //    {
        //        Token = new JwtSecurityTokenHandler().WriteToken(token),
        //        Expires = TokenConfig.DefaultTokenTimeout,
        //        ExpiresAt = TokenConfig.Expires,
        //        Type = "bearer"
        //    };

        //    return accessToken;
        //}

       
        public static HashResult HashPassword(string password, byte[] salt = null)
        {
            if (String.IsNullOrEmpty(password))
                throw new ArgumentNullException("password cannot be null.");

            if (salt == null)
            {
                salt = new byte[128 / 8];

                // Scramble salt
                //using (var rng = RandomNumberGenerator.Create())
                //{
                //    rng.GetBytes(salt);
                //}
            }


            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return new HashResult { HashedPassword = hashed, SaltKey = salt };
        }

        public static bool VerifyPasswords(string password, string hashedPassword)
        {
            var result = HashPassword(password);
            return result.HashedPassword == hashedPassword;
        }

        public class HashResult
        {
            public string HashedPassword { get; set; }
            public byte[] SaltKey { get; set; }

        }



    }

    //public class JsonWebToken
    //{
    //    public string Token { get; set; }
    //    public string Type { get; set; } = "bearer";
    //    public int Expires { get; set; }
    //    public DateTime ExpiresAt { get; set; }
    //    public string RefreshToken { get; set; }
    //}

}
