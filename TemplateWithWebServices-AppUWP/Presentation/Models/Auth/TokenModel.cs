﻿namespace UwpClientApp.Presentation.Models.Auth
{
    public class TokenModel
    {
        public string AccessToken { get; set; }

        public string TokenType { get; set; }

        public int ExpiresIn { get; set; }
    }
}