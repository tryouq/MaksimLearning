namespace MaksimTicAndTacToi;

class Game
{   
    private bool _playerTurn; //False - ход первого игрока
    private Cell[,] _field = new Cell[3, 3];
    private Error? _error;
    private int _playerValue;
    private List<int> _playerInputs = new();
    
    public void Start() 
    {
        Console.WriteLine(GetPlayer);
        if (_error is not null) 
            Console.WriteLine(_error switch
            {
                Error.IsNotDigit => "Введите число",
                Error.IsNotInRange => "Введите число от 1 до 9",
                Error.CellIsBusy => "Данная ячейка занята",
                _ => "Неизвестная ошибка"
            });

        Draw();
        Console.Write("Введите значение ячейки: ");
        SetInput();
        if (_error is not null)
            SetCell();
        
    }

    private void Draw() 
    {
        int number = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(_field[i, j] switch
                {
                    Cell.Empty => number.ToString(),
                    Cell.Zero => "0",
                    Cell.Cross => "x"
                });
                number++;
            }
            Console.WriteLine();
        }
    }

    private void SetInput() 
    {
        string setInput = Console.ReadLine();
        var isSuccess = int.TryParse(setInput, out var userNumber);
        if (isSuccess == false) 
        {
            _error = Error.IsNotDigit;
            return;
        }
        if (userNumber < 1 || userNumber > 9) 
        {
            _error = Error.IsNotInRange;
            return;
        }
        if (_playerInputs.Contains(userNumber)) 
        {
            _error = Error.CellIsBusy;
            return;
        }
        _playerInputs.Add(userNumber);
        _playerValue = userNumber;
    }

    private void SetCell() 
    {
        int i = (_playerValue - 1) / 3;
        int j = (_playerValue - 1) % 3;
        _field[i, j] = !_playerTurn ? Cell.Cross : Cell.Zero;
    }

    private string GetPlayer => !_playerTurn ? "сейчас ходит игрок один" : "сейчас ходит игрок два";
}
