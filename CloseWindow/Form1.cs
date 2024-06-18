namespace CloseWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // sender - объект, который инициировал событие (в данном случае это - сама форма Form1)
            // eventArgs - информация о событии. Например, для MouseMove - это координаты мыши
            FormClosing += (sender, eventArgs) => 
            {
                var result = MessageBox.Show(
                    "Действительно закрыть?",
                    "",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    eventArgs.Cancel = true;
            };
        }



        //protected override void OnFormClosing(FormClosingEventArgs eventArgs)
        //{
        //    var result = MessageBox.Show(
        //        "Действительно закрыть?", 
        //        "", 
        //        MessageBoxButtons.YesNo, 
        //        MessageBoxIcon.Question);

        //    if (result != DialogResult.Yes)
        //        eventArgs.Cancel = true;
        //}
    }
}
