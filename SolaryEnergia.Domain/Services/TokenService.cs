﻿using Microsoft.IdentityModel.Tokens;
using SolaryEnergia.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SolaryEnergia.Domain.Security;
using SolaryEnergia.Domain.Enuns;
using System.Security.Cryptography;

namespace SolaryEnergia.Domain.Services
{
    public class TokenService
    {
        public static string GenerateToken(User user)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Nome),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.GetName()),
            };
            return GenerateToken(claims);
        }
        public static string GenerateToken(IEnumerable<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.ChaveSecreta);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        //atualizar o token

        public static ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.ChaveSecreta)),
                ValidateIssuer = false,
                ValidateAudience = false,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var secutiryToken);

            if (secutiryToken is not JwtSecurityToken jwtSecurityToken)
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        private static List<Tuple<string, string>> _refreshsTokens = new List<Tuple<string, string>>();

        public static void SaveRefreshToken(string username, string refreshToken)
       => _refreshsTokens.Add(new Tuple<string, string>(username, refreshToken));

        public static string GetRefreshToken(string username)
            => _refreshsTokens.FirstOrDefault(x => x.Item1 == username).Item2;

        public static void DeleteRefreshToken(string username, string refreshToken)
        {
            var item = _refreshsTokens.FirstOrDefault(x => x.Item1 == username && x.Item2 == refreshToken);
            _refreshsTokens.Remove(item);
        }
    }
}
