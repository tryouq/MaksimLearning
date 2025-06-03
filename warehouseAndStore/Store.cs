using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Store
{
    public void storeProducts() //Каталог товаров, т.е. журнал для поситителей
    {
        List<String[]> listOfProductsInStore = new List<String[]>();
        // Добавляем массивы продуктов в список товаров
        listOfProductsInStore.Add(new String[4] { "1", "Кола", "70", "2 дня" });
        listOfProductsInStore.Add(new String[4] { "2", "Пиво", "100", "2 дня в будни и 3 дня в выходные" });
        listOfProductsInStore.Add(new String[4] { "3", "Табак для кальяна", "200", "1 день" });
        listOfProductsInStore.Add(new String[4] { "4", "Крылышки KFC", "300", "1 день в четные / 2 дня в не четные" });

        listOfProductsInStore.ForEach(arr => Console.WriteLine($"[{string.Join(", ", arr)}]"));
    }
}
