namespace MaksimTicAndTacToi;

public class Program 
{
    public static void Main(string[] args)
    {
        Console.WriteLine("сейчас ходит игрок First");
        //Console.WriteLine("");
        var number = 1;
        var mass = new int[9];
        for (int i = 0; i < mass.Length; i++)
        {
            mass[i] = number;
            number++;
        }

        Console.Write("Введите номер ячейки: ");
        var inputList = new List<int>();
        var isInputOpen = true;
        do
        {
            var input = Console.ReadLine();
            var isSuccess = int.TryParse(input, out var userNumber);
            if (isSuccess == false)
            {

            }
        } while (isInputOpen);

        var gameField = new Cell[3, 3];

        //Console.WriteLine(JsonConvert.SerializeObject(mass));
    }
}