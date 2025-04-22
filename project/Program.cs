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
using project;
using System.Text.Json;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("----------- Нова пошта -----------");
Console.WriteLine("\tМЕНЮ:");
Console.WriteLine("\t1 послуги");
Console.WriteLine("\t2 зберегти замовлення");
Console.WriteLine("\t3 завантажити замовлення");
Console.WriteLine("\t4 всі посилки");
Console.WriteLine("\t5 видалення посилок");
Console.WriteLine("\t6. Шукати продукти по id");
Console.WriteLine("\t7. Шукати продукти по назві");

NovaPoshta poshta = new();

while (true)
{
    Console.Write("Your choice: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:

            poshta.AddProduct();
           
            break;
        case 2:

            poshta.SaveToFile();

            break;
        case 3:

            poshta.LoadToFile();

            break;
        case 4:

            poshta.ShowAllProduct();

            break;

        case 5:

            poshta.DeleteProduct();

            break;

        case 6:

            poshta.SerchId();

            break;

        case 7:

            poshta.SerchName();

            break;
    }
}
