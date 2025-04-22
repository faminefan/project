using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace project
{
    public class NovaPoshta
    {
        Order product = new();
        List<Order> products = new();
        public void AddProduct()
        {
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
        }
        public void SaveToFile()
        {
            string jsonToSave = JsonSerializer.Serialize(products);
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/products_db.json", jsonToSave);
        }
        public void LoadToFile()
        {
            string jsonToLoad = File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/products_db.json");
            products = JsonSerializer.Deserialize<List<Order>>(jsonToLoad);
        }
        public void ShowAllProduct()
        {
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
        }
        public void DeleteProduct()
        {
            for (int i = 0; i < products.Count; ++i)
                Console.WriteLine($"[{i}] Product: " + products[i].Name);

            Console.Write("Enter number to delete: ");
            int numToDelete = Convert.ToInt32(Console.ReadLine());

            if (numToDelete < 0 || numToDelete >= products.Count)
            {
                Console.WriteLine("Number out of range!");
                return;
            }

            products.RemoveAt(numToDelete);
            Console.WriteLine("Product deleted successfully!");
        }
        public void SerchId()
        {
            for (int i = 0; i < products.Count; ++i)
                Console.WriteLine($"[{i}] Product: " + products[i].Name);

            Console.Write("Enter number to show: ");
            int numToShow = Convert.ToInt32(Console.ReadLine());

            if (numToShow < 0 || numToShow >= products.Count)
            {
                Console.WriteLine("Number out of range!");
                return;
            }
            var itemToShow = products[numToShow];

            itemToShow.Show();
        }
        public void SerchName()
        {
            Console.Write("Enter product name to find: ");
            string nameToFind = Console.ReadLine().Trim();

            var foundItem = products.Find(x => x.Name.Contains(nameToFind));

            if (foundItem == null)
            {
                Console.WriteLine("Product not found!");
                return;
            }

            foundItem.Show();
        }
    }
}
