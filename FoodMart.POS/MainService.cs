namespace FoodMart.POS
{
    public class MainService : IMainService
    {
        public async Task<ResultCode> ExecuteAsync(string[] args, CancellationToken cancellationToken)
        {
            Console.WriteLine("FoodMart Ltd. POS");
            Console.WriteLine("v0.1.0");
            Console.WriteLine("-------------------------------------------------");
            var code = Console.ReadKey(true);
            if (code.Key == ConsoleKey.Q) return ResultCode.Success;
            else
            {
                throw new Exception("something unusual happened here");
            }
        }
    }
}