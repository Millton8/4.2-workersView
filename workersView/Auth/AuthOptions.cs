﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace workersView.Auth
{
    public class AuthOptions
    {
        //public const string ISSUER = "MyAuthServer"; // издатель токена
        //public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        const string KEY = "cfhcfghfghytry1236435";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
