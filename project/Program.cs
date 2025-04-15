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
Console.WriteLine("\t5 видалення посилок");
Console.WriteLine("\t6. Шукати продукти по id");
Console.WriteLine("\t7. Шукати продукти по назві");
Console.WriteLine("\t8. виконаний продукт");



while (true)
{
    Console.Write("Your choice: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            //
           
            break;
        case 2:
            
            break;
        case 3:

            break;
        case 4:
       
            break;

        case 5:
           
            break;

        case 6:
            
            break;

        case 7:
            
            break;
    }
}
