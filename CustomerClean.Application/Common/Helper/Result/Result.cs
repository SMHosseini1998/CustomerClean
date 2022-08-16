using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClean.Application.Common.Helper.Result
{
    public class Result : IResult
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public static IResult Fail() => new Result { Succeeded = false };
        public static IResult Fail(string message) => new Result { Succeeded = false, Message = message };
        public static Task<IResult> FailAsync() => Task.FromResult<IResult>(Result.Fail());
        public static Task<IResult> FailAsync(string message) => Task.FromResult<IResult>(Result.Fail(message));
        public static IResult Success() => new Result { Succeeded = true };

        public static IResult Success(string message) => new Result() { Succeeded = true, Message = message };

        public static Task<IResult> SuccessAsync() => Task.FromResult<IResult>(Result.Success());

        public static Task<IResult> SuccessAsync(string message) => Task.FromResult<IResult>(Result.Success(message));
    }

    public class Result<T> : Result, IResult<T>, IResult
    {
        public T Data { get; set; }
        public static Result<T> Fail() => new Result<T> { Succeeded = false };
        public static Result<T> Fail(string message) => new Result<T> { Succeeded = false, Message = message };
        public static Task<Result<T>> FailAsync() => Task.FromResult<Result<T>>(Result<T>.Fail());
        public static Task<Result<T>> FailAsync(string message) => Task.FromResult<Result<T>>(Result<T>.Fail(message));
        public static Result<T> Success() => new() { Succeeded = true };
        public static Result<T> Success(string message) => new() { Succeeded = true, Message = message };
        public static Result<T> Success(T data) => new Result<T> { Succeeded = true, Data = data };

        public static Result<T> Success(T data, string message) =>
            new Result<T> { Succeeded = true, Data = data, Message = message };

        public static Task<Result<T>> SuccessAsync() => Task.FromResult<Result<T>>(Result<T>.Success());

        public static Task<Result<T>> SuccessAsync(string message) =>
            Task.FromResult<Result<T>>(Result<T>.Success(message));

        public static Task<Result<T>> SuccessAsync(T data) => Task.FromResult<Result<T>>(Result<T>.Success(data));

        public static Task<Result<T>> SuccessAsync(T data, string message) =>
            Task.FromResult(Success(data, message));
    }
}