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