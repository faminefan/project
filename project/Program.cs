using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class NovaPoshta
{
    // Список послуг
    private List<string> services = new List<string>();

    // Список замовлень
    private List<Order> orders = new List<Order>();

    // Шляхи до файлів
    private const string ServicesFilePath = "services.txt";
    private const string OrdersFilePath = "orders.txt";
    private const string CompletedOrdersFilePath = "completed_orders.txt";

    // Конструктор
    public NovaPoshta()
    {
        LoadServices();
        LoadOrders();
    }

    // Завантаження послуг з файлу
    private void LoadServices()
    {
        if (File.Exists(ServicesFilePath))
        {
            services = File.ReadAllLines(ServicesFilePath).ToList();
        }
    }

    // Збереження послуг у файл
    private void SaveServices()
    {
        File.WriteAllLines(ServicesFilePath, services);
    }

    // Завантаження замовлень з файлу
    private void LoadOrders()
    {
        if (File.Exists(OrdersFilePath))
        {
            var lines = File.ReadAllLines(OrdersFilePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                orders.Add(new Order
                {
                    Id = int.Parse(parts[0]),
                    CustomerName = parts[1],
                    Service = parts[2],
                    IsCompleted = bool.Parse(parts[3])
                });
            }
        }
    }

    // Збереження замовлень у файл
    private void SaveOrders()
    {
        var lines = orders.Select(o => $"{o.Id}|{o.CustomerName}|{o.Service}|{o.IsCompleted}");
        File.WriteAllLines(OrdersFilePath, lines);
    }

    // Збереження виконаних замовлень у файл
    private void SaveCompletedOrders()
    {
        var completedOrders = orders.Where(o => o.IsCompleted).ToList();
        var lines = completedOrders.Select(o => $"{o.Id}|{o.CustomerName}|{o.Service}");
        File.WriteAllLines(CompletedOrdersFilePath, lines);
    }

    // Вивід послуг
    public void DisplayServices()
    {
        Console.WriteLine("Доступні послуги:");
        foreach (var service in services)
        {
            Console.WriteLine($"- {service}");
        }
    }

    // Додавання послуги
    public void AddService(string service)
    {
        services.Add(service);
        SaveServices();
        Console.WriteLine($"Послуга '{service}' додана.");
    }

    // Редагування послуги
    public void EditService(int index, string newService)
    {
        if (index >= 0 && index < services.Count)
        {
            services[index] = newService;
            SaveServices();
            Console.WriteLine($"Послуга змінена на '{newService}'.");
        }
        else
        {
            Console.WriteLine("Невірний індекс послуги.");
        }
    }

    // Видалення послуги
    public void DeleteService(int index)
    {
        if (index >= 0 && index < services.Count)
        {
            var service = services[index];
            services.RemoveAt(index);
            SaveServices();
            Console.WriteLine($"Послуга '{service}' видалена.");
        }
        else
        {
            Console.WriteLine("Невірний індекс послуги.");
        }
    }

    // Прийом замовлення
    public void PlaceOrder(string customerName, string service)
    {
        if (services.Contains(service))
        {
            var order = new Order
            {
                Id = orders.Count + 1,
                CustomerName = customerName,
                Service = service,
                IsCompleted = false
            };
            orders.Add(order);
            SaveOrders();
            Console.WriteLine("Замовлення прийнято. Квитанція:");
            PrintReceipt(order);
        }
        else
        {
            Console.WriteLine("Така послуга недоступна.");
        }
    }

    // Друк квитанції
    private void PrintReceipt(Order order)
    {
        Console.WriteLine("--- Квитанція ---");
        Console.WriteLine($"ID: {order.Id}");
        Console.WriteLine($"Клієнт: {order.CustomerName}");
        Console.WriteLine($"Послуга: {order.Service}");
        Console.WriteLine("-----------------");
    }

    // Відмітка про виконання замовлення
    public void MarkOrderAsCompleted(int orderId)
    {
        var order = orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            order.IsCompleted = true;
            SaveOrders();
            SaveCompletedOrders();
            Console.WriteLine($"Замовлення #{orderId} відмічено як виконане.");
        }
        else
        {
            Console.WriteLine("Замовлення не знайдено.");
        }
    }
}

// Клас замовлення
class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string Service { get; set; }
    public bool IsCompleted { get; set; }
}

// Головний клас програми
class Program
{
    static void Main(string[] args)
    {
        var novaPoshta = new NovaPoshta();

        while (true)
        {
            Console.WriteLine("\nОберіть дію:");
            Console.WriteLine("1. Вивести послуги");
            Console.WriteLine("2. Додати послугу");
            Console.WriteLine("3. Редагувати послугу");
            Console.WriteLine("4. Видалити послугу");
            Console.WriteLine("5. Прийняти замовлення");
            Console.WriteLine("6. Відмітити замовлення як виконане");
            Console.WriteLine("7. Вийти");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    novaPoshta.DisplayServices();
                    break;
                case "2":
                    Console.Write("Введіть назву послуги: ");
                    var service = Console.ReadLine();
                    novaPoshta.AddService(service);
                    break;
                case "3":
                    Console.Write("Введіть індекс послуги: ");
                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        Console.Write("Введіть нову назву послуги: ");
                        var newService = Console.ReadLine();
                        novaPoshta.EditService(index, newService);
                    }
                    else
                    {
                        Console.WriteLine("Невірний індекс.");
                    }
                    break;
                case "4":
                    Console.Write("Введіть індекс послуги: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteIndex))
                    {
                        novaPoshta.DeleteService(deleteIndex);
                    }
                    else
                    {
                        Console.WriteLine("Невірний індекс.");
                    }
                    break;
                case "5":
                    Console.Write("Введіть ім'я клієнта: ");
                    var customerName = Console.ReadLine();
                    Console.Write("Введіть назву послуги: ");
                    var orderService = Console.ReadLine();
                    novaPoshta.PlaceOrder(customerName, orderService);
                    break;
                case "6":
                    Console.Write("Введіть ID замовлення: ");
                    if (int.TryParse(Console.ReadLine(), out int orderId))
                    {
                        novaPoshta.MarkOrderAsCompleted(orderId);
                    }
                    else
                    {
                        Console.WriteLine("Невірний ID.");
                    }
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }
        }
    }
}