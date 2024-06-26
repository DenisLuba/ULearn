namespace MyFormsTableGame;

internal class GameModel(int size)
{
    bool[,] Game { get; init; } = new bool[size, size];

    public int Size { get => size; }

    public void Start()
    {
        for (int row = 0; row < Size; row++)
            for (int column = 0; column < Size; column++)
                SetState(row, column, (row + column) % 2 == 0);
    }

    void SetState(int row, int column, bool state)
    {
        Game[row, column] = state;
        if (StateChanged != null)
            StateChanged(row, column, state);
    }

    void FlipState(int row, int column) => SetState(row, column, !Game[row, column]);

    public void Flip(int row, int column)
    {
        for (int iRow = 0; iRow < Size; iRow++)
            if (iRow != row)
                FlipState(iRow, column);

        for (int iColumn = 0; iColumn < Size; iColumn++)
            if (iColumn != column)
                FlipState(row, iColumn);

        FlipState(row, column);
    }

    public event Action<int, int, bool>? StateChanged;
}
