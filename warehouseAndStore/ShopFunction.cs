using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warehouseAndStore
{
    public abstract class Product  // Объявляем класс
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public abstract decimal GetPriceWithDiscount(DateOnly date, int visitorCount);
        public abstract DateOnly GetArrivalDate(DateOnly date);
    }
    public class Colla : Product
    {
        public override DateOnly GetArrivalDate(DateOnly date)//to do добить все продукты с условиями
        {
            return date.AddDays(2);
        }

        public override decimal GetPriceWithDiscount(DateOnly date, int visitorCount)
        {
            if (date.IsHololliday())
                return Price * 0.9m;
            else
                return Price;
        }
    }
    class ShopFunction
    {
        private Product[] products = new Product[5];
        private List<(Product product, DateOnly date)> orderList = new List<(Product product, DateOnly date)>();//Лист с анонимными объектами 
        public void InitializeProductsInShop()//Инициализация продуктов
        {
             // Индексы 1-4
            products[1] = new Colla { Id = 1, Name = "Кола", Price = 70, Count = 3 };
            products[2] = new Product { Id = 2, Name = "Пиво", Price = 100, Count = 2 };
            products[3] = new Product { Id = 3, Name = "Табак", Price = 200, Count = 4 };
            products[4] = new Product { Id = 4, Name = "КФС", Price = 300, Count = 5 };
        }
        public string GetOrderList()
        {
            return string.Join("\n", 
                orderList
                    .GroupBy(item => new { item.date, item.product.Id, item.product.Name })
                    .Select(item => $"{item.Key.Id} {item.Key.Name} {item.Count()} {item.Key.date}")
                );
        }
        public void GetProductListInShop()//Команда для получения списка товаров, которые в данный момент есть в магазине 
        {
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine($"ID: {products[i].Id}, Название: {products[i].Name}, Цена: {products[i].Price} руб., Количество: {products[i].Count}");
            }
        }
        public decimal BuyProduct(int id, DateOnly day, int visitorCounter) 
        {
            if (products[id].Count > 0)//Если у нас кол-во не 0, то вычитаем единицу товара
            {
                products[id].Count--;
                return products[id].GetPriceWithDiscount(day, visitorCounter);
            }
            else 
            {
                OrderProduct(id, day);//заказываем продукт
                return 0;
            }
        }
        public void OrderProduct(int id, DateOnly day) 
        {
            orderList.Add(new(products[id], products[id].GetArrivalDate(day))); 
        }
        public void CheckOrders(DateOnly day)
        {
            foreach (var order in orderList)
                if (order.date == day)
                    order.product.Count += 1;
            orderList = orderList.Where(order => order.date != day).ToList();
        }
    }
}
