using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
