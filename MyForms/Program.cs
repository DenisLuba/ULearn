using System.Text.RegularExpressions;

public class MyForm : Form
{
    public MyForm()
    {
        var label = new Label
        {
            Location = new Point(0, 0),
            Size = new Size(ClientSize.Width, 30),
            Text = "Enter a number"
        };

        var box = new TextBox
        {
            Location = new Point(0, label.Bottom),
            Size = label.Size
        };

        var button = new Button
        {
            Location = new Point(0, box.Bottom),
            Size = label.Size,
            Text = "Increment!"
        };

        Controls.Add(label);
        Controls.Add(box);
        Controls.Add(button);

        button.Click += (sender, args) =>
        {
            string text = new Regex(@"\D").Replace(box.Text, "");
            box.Text = (int.Parse(text == "" ? "0" : text) + 1).ToString();
        };
    }

    public static void Main()
    {
        Application.Run(new MyForm());
    }
}