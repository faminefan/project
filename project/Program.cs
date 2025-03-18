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
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("----------- Нова пошта -----------");
Console.WriteLine("\tМЕНЮ:");
Console.WriteLine("\t1 послуги");
Console.WriteLine("\t2 замовлення посилок");
Console.WriteLine("\t3 товари які прийшли");
Console.WriteLine("\t4 зберегти замовлення");
Console.WriteLine("\t5 Замовлення які зроблення");

Order product = new();

while (true)
{
    Console.Write("Your choice: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            //
            Console.WriteLine("Enter services name: ");
            product.Name =  Console.ReadLine();
            Console.WriteLine("Enter Object: ");
            product.Object = Console.ReadLine();
            Console.WriteLine("Enter Quantity: ");
            product.Quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Place: ");
            product.Place = Console.ReadLine();
            Console.WriteLine("Enter Data: ");
            product.Data = Console.ReadLine();
            break;
        case 4:
            Console.WriteLine("------- New mail ---------");
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Object: {product.Object}");
            Console.WriteLine($"Quantity: {product.Quantity}");
            Console.WriteLine($"Place: {product.Place}");
            Console.WriteLine($"Data: {product.Data}");
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
