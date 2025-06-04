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
        public Product[] products = new Product[5];
        public void InitializeProductsInShop()//Инициализация продуктов
        {
             // Индексы 1-4
            products[1] = new Product { Id = 1, Name = "Кола", Price = 70, Count = 3 };
            products[2] = new Product { Id = 2, Name = "Пиво", Price = 100, Count = 2 };
            products[3] = new Product { Id = 3, Name = "Табак", Price = 200, Count = 4 };
            products[4] = new Product { Id = 4, Name = "КФС", Price = 300, Count = 5 };
        }
        public void ActivityProductInShop(int id, int count)//Действия с продуктом, добавление или вычитание 
        {
            int idProduct = id;
            int countProduct = count;
            products[idProduct].Count += countProduct;
        }
        public void GetProductListInShop()//Команда для получения списка товаров, которые в данный момент есть в магазине 
        {
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine($"ID: {products[i].Id}, Название: {products[i].Name}, Цена: {products[i].Price} руб., Количество: {products[i].Count}");
            }
        }
        public void BuyProduct(int id) 
        {
            if (products[id].Count != 0)//Если у нас кол-во не 0, то вычитаем единицу товара
                ActivityProductInShop(id, -1);
            else 
                OrderProduct(id);//заказываем продукт
        }
        public void OrderProduct(int id) 
        {
            if (products[id].Count == 0)
                ActivityProductInShop(id, 1);
        }

    }
}
