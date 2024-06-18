using System.Text.RegularExpressions;

public class MyForm : Form
{
    Label label;
    TextBox textBox;
    Button button;

    public MyForm()
    {

        label = new Label();
        label.Text = "Enter a number";
        textBox = new TextBox();
        button = new Button { Text = "Increment!" };

        Controls.Add(label);
        Controls.Add(textBox);
        Controls.Add(button);

        button.Click += MyOnClick;
        // button.Click += (sender, args) => { ... };

        // Фиксирует размер окна
        //FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;

        // Запрещает развернуть окно
        //MaximizeBox = false;

        // Вызывается в тот момент, когда происходит изменение окна, но не в момент загрузки окна
        //SizeChanged += (sender, args) => { ... };
        SizeChanged += new EventHandler(MyOnSizeChanged);

        // Вызывается в момент загрузки окна
        Load += (sender, args) => OnSizeChanged(EventArgs.Empty); // вызывает SizeChanged без событий
    }

    private void MyOnSizeChanged(object? sender, EventArgs args)
    {
        label.Size = new Size(ClientSize.Width, 30);
        textBox.Size = label.Size;
        button.Size = label.Size;

        var y = ( ClientSize.Height - label.Size.Height - textBox.Size.Height - button.Size.Height ) / 2;
        label.Location = new Point(0, y);
        textBox.Location = new Point(0, label.Bottom);
        button.Location = new Point(0, textBox.Bottom);
    }

    void MyOnClick(object? sender, EventArgs args)
    {
        string text = new Regex(@"\D").Replace(textBox.Text, "");
        textBox.Text = (int.Parse(text == "" ? "0" : text) + 1).ToString();
    }

    public static void Main()
    {
        Application.Run(new MyForm());
    }
}