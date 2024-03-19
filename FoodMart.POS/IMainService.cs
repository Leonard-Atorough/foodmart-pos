namespace FoodMart.POS
{
    public interface IMainService
    {
        Task<ResultCode> ExecuteAsync(string[] args, CancellationToken cancellation);
    }
}