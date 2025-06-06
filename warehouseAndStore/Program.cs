namespace warehouseAndStore;
public class Program
{
    public static void Main(String[] args)
    {
        //Присвоение переменных для вызова классов
        var storeList = new Store();
        var shop = new ShopFunction();
        var helper = new MyDateTimeHelper();
        int dayNumberIso = helper.GetIsoDayOfWeekNumber(); //Какая - то штука чтобы распарсить дни недели на инт
        Random rand = new Random(); //Завел для рандома статический метод, или он ругается

        Console.WriteLine(dayNumberIso);
        shop.InitializeProductsInShop();//Метод сразу заполняющий массив продуктов
        Console.WriteLine("Введите кол-во дней работы магазина: ");
        string setDays = Console.ReadLine();
        //Основной механизм магазина
        for (int i = 1; i <= Convert.ToInt32(setDays);) 
        {
            for (int j = 1; j <= rand.Next(5, 10);)
            {
                Console.WriteLine("Напишите запрос: ");
                string setInput = Console.ReadLine(); //Считывание переменной
                if (setInput == "store getProductList") //Вызов списка для получение каталога продуктов
                {
                    storeList.storeProducts();
                    j++;
                }
                if (setInput == "shop getProductList")//Вызов имеющихся продуктов в магазине
                {
                    shop.GetProductListInShop();
                    j++;
                }
                if (setInput.StartsWith("shop buy")) //Вызов на покупку продуктов
                {
                    shop.BuyProduct(setInput[2]);
                    j++;
                }
                i++;
                shop.CountDays(1);
            }
        }
    }
}