﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Interstellar.FreeCourse.Shared.Dtos
{
    public class Response<T>
    {
        public T Data { get; private set; }
        [JsonIgnore]//BU attr. sayesinde json serialize edilmeyecek. *Yazılım içersinde kullanılacak kullanıcı ya gönderilmeyecek.
        public int StatusCode { get; private set; }
        [JsonIgnore]
        public bool IsSuccessful { get; private set; }
        public List<string> Errors { get; set; }


        //Static Factory method
        public static Response<T> Success(T data, int statusCode)// Bu class üretildiğinde bu method ile nesne örneğini alabileceğim.
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }
        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default(T), StatusCode = statusCode, IsSuccessful = true };
        }
        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new Response<T> { Errors = errors, StatusCode = statusCode, IsSuccessful = false };
        }
        public static Response<T> Fail(string error, int statusCode)
        {
            return new Response<T> { Errors = new List<string> { error }, StatusCode = statusCode, IsSuccessful = false };
        }
    }
}