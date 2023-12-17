using FoodMart.POS.Shared;

bool process = true;
POSService service;

Console.WriteLine("FoodMart Ltd. POS");
Console.WriteLine("v0.1.0");
Console.WriteLine("-------------------------------------------------");


while (process)
{

    Console.WriteLine(" Welcome cashier. See your options below:");
    Console.WriteLine(" Enter 0 to exit the pos system");
    Console.WriteLine(" Enter 1 to begin processing a sale");
    var input = Console.ReadLine();

    switch (input)
    {
        case "0":
            process = false;
            break;
        case "1":
            StartTransaction();
            break;
        default:
            break;
    }
}

void StartTransaction()
{
    service = new POSService();
    Console.WriteLine("---------------------Inventory-------------------");
    Console.WriteLine(InventoryAccess.GetInventory());
    Console.WriteLine("---------------------Inventory-------------------");

    bool isTransacting = true;
    while (isTransacting)
    {
        Console.WriteLine("Please input the name of the item or type end to finish the transaction");
        Console.WriteLine("-------------------------------------------------\r\n");

        var input = Console.ReadLine();
        Console.WriteLine("---------------------\r\n");
        if (string.Equals(input, "end", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Please input the customers total payment");
            var payment = Console.ReadLine();
            var isValidInput = TryParseInput(payment, out var result);
            if (isValidInput)
            {
                isTransacting = false;
                Thread.Sleep(1000);
                Console.WriteLine(service.ProcessPayment(result));
            }
        }
        else
        {
            _ = service.ScanItem(input, out string? currentBasket);
            Console.WriteLine(currentBasket);
        }
        Console.WriteLine("---------------------\r\n");
    }
}

bool TryParseInput(string input, out decimal parseResult)
{
    bool success = decimal.TryParse(input, out var result);
    parseResult = result;
    return success;
}
