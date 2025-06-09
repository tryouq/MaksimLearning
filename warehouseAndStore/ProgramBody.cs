using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warehouseAndStore
{
    class ProgramBody()
    {
        //Присвоение переменных для вызова классов
        Store storeList = new Store();
        ShopFunction shop = new ShopFunction();
        Random rand = new Random(); //Завел для рандома статический метод, или он ругается
        DateOnly currentDate = DateOnly.FromDateTime(DateTime.Today);
        public void BodyCallInitialize() { shop.InitializeProductsInShop(); }
        public void Body()
        {   
            decimal sum = 0;
            int visitorsCounter = rand.Next(5, 10);
            Console.WriteLine($"Today {currentDate} the store has opened and will serve {visitorsCounter} visitors");
            shop.CheckOrders(currentDate);//Проверяем покупки
            Console.WriteLine(currentDate);
            for (int j = 1; j <= visitorsCounter;)
            {
                Console.WriteLine("Напишите запрос: ");
                string setInput = Console.ReadLine(); //Считывание переменной
                if (setInput == "store getProductList") //Вызов списка для получение каталога продуктов
                {
                    storeList.storeProducts();
                }
                if (setInput == "shop getProductList")//Вызов имеющихся продуктов в магазине
                {
                    shop.GetProductListInShop();
                }
                if (setInput.StartsWith("shop buy")) //Вызов на покупку продуктов
                {
                    sum += shop.BuyProduct(int.Parse(setInput.Split(' ')[2]), currentDate, j);
                    j++;
                }
                if (setInput.StartsWith("store order"))
                {
                    shop.OrderProduct(int.Parse(setInput.Split(' ')[2]), currentDate);
                    j++;
                }
                else
                    Console.WriteLine("Вероятнее всего вы ввели некоректный запрос!");
            }
            currentDate = currentDate.AddDays(1);
            Console.WriteLine($"The store's profit was {sum}\nGoods were ordered from the store\n{shop.GetOrderList()}");
        }
    }
}
