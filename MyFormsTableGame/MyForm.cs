using System.Data.Common;

namespace MyFormsTableGame;

partial class MyForm : Form
{
    GameModel game;
    TableLayoutPanel table;

    public MyForm(GameModel game)
    {
        this.game = game;
        table = new TableLayoutPanel();

        AlignTable();
        FillInTableWithButtons();

        table.Dock = DockStyle.Fill;
        Controls.Add(table);

        game.StateChanged += ChangeColor;

        game.Start();
    }

    void AlignTable()
    {
        for (int i = 0; i < game.Size; i++)
        {
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / game.Size));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / game.Size));
        }
    }

    void FillInTableWithButtons()
    {
        for (int column = 0; column < game.Size; column++)
            for (int row = 0; row < game.Size; row++)
            {
                var iRow = row;
                var iColumn = column;
                var button = new Button();
                button.Dock = DockStyle.Fill;
                button.Click += (sender, args) => game.Flip(iRow, iColumn);
                table.Controls.Add(button, iColumn, iRow);
            }
    }

    void ChangeColor(int row, int column, bool state)
        => (table.GetControlFromPosition(column, row) as Button)!.BackColor = state
                ? Color.Black
                : Color.White;
}
