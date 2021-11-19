using System;
using System.Threading.Tasks;
using WebClient.Requests;
using static WebClient.CustomerCreateRequest;
using static WebClient.Requests.WebApiRequest;

namespace WebClient
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Завести случайного клиента");
                Console.WriteLine("2. Получить клиента по Id\r\n");

                var choiceKey = Console.ReadKey().Key;

                switch (choiceKey)
                {   
                    case ConsoleKey.D1:
                        Console.Clear();
                        var rndcustomer = GetRandomCustomer();
                        var newCustomerId = await WebApiRequest.CreateCustomerAsync(rndcustomer);
                        Console.WriteLine($"\r\nId созданного юзера - {newCustomerId}\r\n");
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Введите Id для поиска\r\n");

                        var isNumeric = long.TryParse(Console.ReadLine(),out long id);

                        if (isNumeric)
                        {
                            var customer = await WebApiRequest.GetCustomerAsync(id);
                            if (customer != null)
                            {
                                Console.WriteLine("Вы выбрали:\r\n");
                                Console.WriteLine($"{customer.Id}.{customer.Firstname} {customer.Firstname}\r\n");
                            }
                            else
                            {
                                Console.WriteLine("Не удалось получить клиента, попробуйте еще раз\r\n");
                            }
                                
                        }
                        else
                        {
                            Console.WriteLine("Ошибка ввода\r\n");
                        };
                        break;

                }
            }
        }

    }
}