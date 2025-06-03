namespace warehouseAndStore;
public class Program
{
    public static void Main(String[] args)
    {
        string setInput = Console.ReadLine(); //Считывание переменной
        var storeList = new Store(); //Присвоение переменной для вызова класса
        var shop = new Shop();
        
        if(setInput == "store getProductList") //Вызов списка для получение каталога продуктов
            storeList.storeProducts();

        if (setInput == "Добавить продукты") 
        {
            string setInt = Console.ReadLine();
            string setCount = Console.ReadLine();
            shop.ProductsInShop(Convert.ToInt32(setInt), Convert.ToInt32(setCount));
        }
    }
}