using System.Drawing;
using System.Windows.Forms;

namespace MyFormsGraphics
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            ClientSize = new System.Drawing.Size(300, 300);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;

            // Изменяет начало системы координат, добавляя указанное преобразование
            // к матрицу преобразования этого System.Drawing.Graphics.
            // (т.е. начало координат переносим, в данном случае, в центр холста)
            graphics.TranslateTransform(ClientSize.Width / 2, ClientSize.Height / 2);
            // Применяет указанное вращение к матрице преобразования этого System.Drawing.Graphics.
            // (т.е. поворачиваем холст, в данном случае, на 10 градусов)
            graphics.RotateTransform(10);
            // Применяет указанную операцию масштабирования к матрице преобразования этого
            // System.Drawing.Graphics, добавляя его к матрице преобразования объекта.
            // (т.е. уменьшаем масштаб холста до 70%, в данном случае)
            graphics.ScaleTransform(0.7f, 0.7f);
            // возвращаем начало координат на свое место в точку (0, 0)
            graphics.TranslateTransform(-ClientSize.Width / 2, -ClientSize.Height / 2);


            graphics.DrawLine(new Pen(Color.Red, 5), new Point(0, 0), new Point(50, 100));

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            graphics.DrawLine(new Pen(Color.Green, 5), 0, 0, 100, 50);

            graphics.FillRectangle(Brushes.Green, 150, 200, 100, 50);

            graphics.DrawString("Some text here", new Font("Arial", 16), Brushes.Black, new Point(0, 250));

            graphics.DrawString(
                "Some very long text",
                new Font("Arial", 12),
                Brushes.DarkRed,
                new Rectangle(150, 200, 100, 50),
                new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.FitBlackBox
                });
        }
    }
}
