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
Console.WriteLine("\t6. Шукати продукти по id");
Console.WriteLine("\t7. Шукати продукти по назві");
Console.WriteLine("\t8. виконаний продукт");

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
                item.Show();
            }
            break;

        case 5:
            for (int i = 0; i < products.Count; ++i)
                Console.WriteLine($"[{i}] Product: " + products[i].Name);

            Console.Write("Enter number to delete: ");
            int numToDelete = Convert.ToInt32(Console.ReadLine());

            if (numToDelete < 0 || numToDelete >= products.Count)
            {
                Console.WriteLine("Number out of range!");
                break;
            }

            products.RemoveAt(numToDelete);
            Console.WriteLine("Product deleted successfully!");
            break;

        case 6:
            for (int i = 0; i < products.Count; ++i)
                Console.WriteLine($"[{i}] Product: " + products[i].Name);

            Console.Write("Enter number to show: ");
            int numToShow = Convert.ToInt32(Console.ReadLine());

            if (numToShow < 0 || numToShow >= products.Count)
            {
                Console.WriteLine("Number out of range!");
                break;
            }
            var itemToShow = products[numToShow];

            itemToShow.Show();
            break;

        case 7:
            Console.Write("Enter product name to find: ");
            string nameToFind = Console.ReadLine().Trim();

            var foundItem = products.Find(x => x.Name.Contains(nameToFind));

            if (foundItem == null)
            {
                Console.WriteLine("Product not found!");
                break;
            }

            foundItem.Show();
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
    public void Show()
    {
        Console.WriteLine("------- Product ---------");
        Console.WriteLine($"Name: {this.Name}");
        Console.WriteLine($"Object: {this.Object}");
        Console.WriteLine($"Place: {this.Place}");
        Console.WriteLine($"Quantity: {this.Quantity}");
        Console.WriteLine($"Data: {this.Data}");
    }
}