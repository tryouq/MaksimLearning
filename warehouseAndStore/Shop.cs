using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warehouseAndStore
{
    public class Product  // Объявляем класс
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
    class Shop
    {
        public void ProductsInShop(int id, int count)
        {
            int idProduct = id;
            int countProduct = count;

            Product[] products = new Product[5]; // Индексы 1-4
            products[1] = new Product { Id = 1, Name = "Кола", Price = 70, Count = 0 };
            products[2] = new Product { Id = 2, Name = "Пиво", Price = 100, Count = 0 };
            products[3] = new Product { Id = 3, Name = "Табак", Price = 200, Count = 0 };
            products[4] = new Product { Id = 4, Name = "КФС", Price = 300, Count = 0 };

            products[idProduct].Count += countProduct;
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine($"ID: {products[i].Id}, Название: {products[i].Name}, Цена: {products[i].Price} руб., Количество: {products[i].Count}");
            }
        }
    }
}
