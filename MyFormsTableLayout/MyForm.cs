using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyFormsTableLayout
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            var label = new Label
            {
                Text = "Enter a number",
                Dock = DockStyle.Fill
            };

            var box = new TextBox
            {
                Dock = DockStyle.Fill
            };

            var button = new Button
            {
                Text = "Increment",
                Dock = DockStyle.Fill
            };

            var table = new TableLayoutPanel();
            table.RowStyles.Clear();
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            table.Controls.Add(new Panel(), 0, 0);
            table.Controls.Add(label, 0, 1);
            table.Controls.Add(box, 0, 2);
            table.Controls.Add(button, 0, 3);
            table.Controls.Add(new Panel(), 0, 4);

            table.Dock = DockStyle.Fill;
            Controls.Add(table);

            button.Click += (sender, args) =>
            {
                var text = new Regex(@"\D").Replace(box.Text, "");
                box.Text = (int.Parse(text == "" ? "0" : text) + 1).ToString();
            };
        }
    }
}
