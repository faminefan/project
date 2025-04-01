/* 9. ------------------ - Нова пошта
    Створити програму для імітації роботи Нової пошти. У програмі передбачити наступні сервіси
	Вивід послуг пошти
	Доповнення(редагування, видалення ) послуги
    Прийом замовлення про пересилку товару(друк квитанції, прийом товару, оплата, реєстрація про замовлення у базі) 
	Відмітка про виконання замовлення(доставку товарів)
	Зберігати та завантажувати у(з) файлі(у) замовлені послуги
	Виконані послуги зберігати у іншому файлі
	КЛАС Замовлення Послуга
*/
using System.Text.Json;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("----------- Нова пошта -----------");
Console.WriteLine("\tМЕНЮ:");
Console.WriteLine("\t1 послуги");
Console.WriteLine("\t2 зберегти замовлення");
Console.WriteLine("\t3 завантажити замовлення");
Console.WriteLine("\t4 всі посилки");
Console.WriteLine("\t5 замовлення посилок");
Console.WriteLine("\t6 Замовлення які зроблені");

Order product = new();
List<Order> products = new();

while (true)
{
    Console.Write("Your choice: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            //
            var newItem = new Order();
            Console.WriteLine("Enter services name: ");
            newItem.Name = Console.ReadLine();
            Console.WriteLine("Enter Object: ");
            newItem.Object = Console.ReadLine();
            Console.WriteLine("Enter Quantity: ");
            newItem.Quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Place: ");
            newItem.Place = Console.ReadLine();
            Console.WriteLine("Enter Data: ");
            newItem.Data = Console.ReadLine();
            products.Add(newItem);
            break;
        case 2:
            string jsonToSave = JsonSerializer.Serialize(products);
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/products_db.json", jsonToSave);
            break;
        case 3:
            string jsonToLoad = File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/products_db.json");
            products = JsonSerializer.Deserialize<List<Order>>(jsonToLoad);
            break;
        case 4:
            foreach (var item in products)
            { 
                Console.WriteLine("------- New mail ---------");
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Object: {item.Object}");
                Console.WriteLine($"Quantity: {item.Quantity}");
                Console.WriteLine($"Place: {item.Place}");
                Console.WriteLine($"Data: {item.Data}");
            }
            break;  
    }
}
public class Order
{
    public string Name { get; set; }
    public string Object { get; set; }
    public int  Quantity { get; set; }
    public string Place { get; set; }
    public string Data { get; set; }
}

public class Service
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Receipts { get; set; }
}
