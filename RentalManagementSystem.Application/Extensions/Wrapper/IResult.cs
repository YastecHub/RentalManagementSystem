namespace RentalManagementSystem.Application.Extensions.Wrapper
{
    public interface IResult
    {
        List<string> Messages { get; set; }

        bool IsSuccessful { get; set; }
    }

    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }
}