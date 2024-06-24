using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFormsTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Включает двойную буферизацию, чтобы изображение не мерцало при перерисовке.
            // В таком режиме OnPaint рисует не сразу на окне, а сначала на невидимой картинке (shadow buffer),
            // а потом одномоментно подменяет текущее изображение дорисованной картинкой.
            // Так окно не дорисованную картинку даже не показывает, что предотвращает мерцание.
            DoubleBuffered = true;

            ClientSize = new Size(600, 600);
            var centerX = ClientSize.Width / 2;
            var centerY = ClientSize.Height / 2;
            var size = 100;
            var radius = Math.Min(ClientSize.Width, ClientSize.Height) / 3;

            int time = 0;
            var timer = new Timer();
            timer.Interval = 500;
            timer.Tick += (sender, args) =>
            {
                time++;
                // var graphics = CreateGraphics(); // лучше так не делать,
                // потому что будет мерцание и при скрытии окна и его открытии то, 
                // что было уже нарисовано исчезнет
                Invalidate(); // перерисовываем графику
            };

            timer.Start();

            Paint += (sender, args) =>
            {
                for (int i = 0; i < time; i++)
                {
                    args.Graphics.TranslateTransform(centerX, centerY); // orignin to center
                    args.Graphics.RotateTransform(i * 360f / 10); // поворачиваем на 36 градусов для 10 кружков
                    args.Graphics.FillEllipse(Brushes.Blue, radius - size / 2, -size / 2, size, size); // рисуем кружок
                    args.Graphics.ResetTransform(); // сбрасываем трансформации (origin)
                }
            };
        }
    }
}
