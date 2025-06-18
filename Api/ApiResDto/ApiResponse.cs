﻿namespace Api.ApiResDto
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public ApiResponse() { }

        public ApiResponse(bool success, string? message = null, T? data = default)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
