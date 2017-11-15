﻿namespace UwpClientApp.Presentation.Models
{
    public class ResponseWrapper<T> : ResponseWrapper
    {
        public T Content { get; set; }
    }

    public class ResponseWrapper
    {
        public string ErrorMessage { get; set; }

        public bool IsValid => string.IsNullOrEmpty(ErrorMessage);
    }
}