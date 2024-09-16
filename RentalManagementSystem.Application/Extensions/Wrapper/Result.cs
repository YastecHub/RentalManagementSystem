namespace RentalManagementSystem.Application.Extensions.Wrapper
{
    public class Result : IResult
    {
        public Result()
        {
        }

        public List<string> Messages { get; set; } = [];

        public bool IsSuccessful { get; set; }

        public static IResult Fail() => new Result { IsSuccessful = false };

        public static IResult Fail(string message) => new Result { IsSuccessful = false, Messages = [message] };

        public static IResult Fail(List<string> messages) => new Result { IsSuccessful = false, Messages = messages };

        public static Task<IResult> FailAsync() => Task.FromResult(Fail());

        public static Task<IResult> FailAsync(string message) => Task.FromResult(Fail(message));

        public static Task<IResult> FailAsync(List<string> messages) => Task.FromResult(Fail(messages));

        public static IResult Success() => new Result { IsSuccessful = true };

        public static IResult Success(string message) => new Result { IsSuccessful = true, Messages = [message] };

        public static IResult Success(List<string> messages) => new Result { IsSuccessful = true, Messages = messages };

        public static Task<IResult> SuccessAsync() => Task.FromResult(Success());

        public static async Task<IResult> SuccessAsync(string message) => await Task.FromResult(Success(message));

        public static Task<IResult> SuccessAsync(List<string> messages) => Task.FromResult(Success(messages));
    }

    public class ErrorResult<T> : Result<T>
    {
        public string Source { get; set; }

        public string Exception { get; set; }

        public string ErrorId { get; set; }
        public string SupportMessage { get; set; }
        public int StatusCode { get; set; }
    }

    public class Result<T> : Result, IResult<T>
    {
        public Result()
        {
        }

        public T Data { get; set; }

        public static new Result<T> Fail() => new() { IsSuccessful = false };

        public static new Result<T> Fail(string message) => new() { IsSuccessful = false, Messages = [message] };

        public static ErrorResult<T> ReturnError(string message) => new() { IsSuccessful = false, Messages = [message], StatusCode = 500 };

        public static new Result<T> Fail(List<string> messages) => new() { IsSuccessful = false, Messages = messages };

        public static ErrorResult<T> ReturnError(List<string> messages) => new() { IsSuccessful = false, Messages = messages, StatusCode = 500 };

        public static new Task<Result<T>> FailAsync() => Task.FromResult(Fail());

        public static new Task<Result<T>> FailAsync(string message) => Task.FromResult(Fail(message));

        public static Task<ErrorResult<T>> ReturnErrorAsync(string message) => Task.FromResult(ReturnError(message));

        public static new Task<Result<T>> FailAsync(List<string> messages) => Task.FromResult(Fail(messages));

        public static Task<ErrorResult<T>> ReturnErrorAsync(List<string> messages) => Task.FromResult(ReturnError(messages));

        public static new Result<T> Success() => new() { IsSuccessful = true };

        public static new Result<T> Success(string message) => new() { IsSuccessful = true, Messages = [message] };

        public static new Result<T> Success(List<string> messages) => new() { IsSuccessful = true, Messages = messages };

        public static Result<T> Success(T data) => new() { IsSuccessful = true, Data = data };

        public static Result<T> Success(T data, string message) => new() { IsSuccessful = true, Data = data, Messages = [message] };

        public static Result<T> Success(T data, List<string> messages) => new() { IsSuccessful = true, Data = data, Messages = messages };

        public static new Task<Result<T>> SuccessAsync() => Task.FromResult(Success());

        public static new Task<Result<T>> SuccessAsync(string message) => Task.FromResult(Success(message));

        public static new Task<Result<T>> SuccessAsync(List<string> messages) => Task.FromResult(Success(messages));

        public static Task<Result<T>> SuccessAsync(T data) => Task.FromResult(Success(data));

        public static Task<Result<T>> SuccessAsync(T data, string message) => Task.FromResult(Success(data, message));

        public static Task<Result<T>> SuccessAsync(T data, List<string> messages) => Task.FromResult(Success(data, messages));
    }
}