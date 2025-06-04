namespace warehouseAndStore;
public class Program
{
    public static void Main(String[] args)
    {
        //Присвоение переменных для вызова классов
        var storeList = new Store();
        var shop = new Shop();
        var helper = new MyDateTimeHelper();
        int dayNumberIso = helper.GetIsoDayOfWeekNumber();//Какая - то штука чтобы распарсить дни недели на инт

        shop.InitializeProductsInShop();//Метод сразу заполняющий массив продуктов
        Console.WriteLine("Введите кол-во дней работы магазина: ");
        string setDays = Console.ReadLine();
        Console.WriteLine("Напишите запрос: ");
        string setInput = Console.ReadLine(); //Считывание переменной
        
        if (setInput == "store getProductList") //Вызов списка для получение каталога продуктов
            storeList.storeProducts();
        if (setInput == "shop getProductList") //Вызов имеющихся продуктов в магазине
            shop.GetProductListInShop();
        if (setInput.StartsWith("shop buy")) //Вызов на покупку продуктов
            shop.BuyProduct(setInput[2]);
    }
}