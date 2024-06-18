namespace CloseWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // sender - ������, ������� ����������� ������� (� ������ ������ ��� - ���� ����� Form1)
            // eventArgs - ���������� � �������. ��������, ��� MouseMove - ��� ���������� ����
            FormClosing += (sender, eventArgs) => 
            {
                var result = MessageBox.Show(
                    "������������� �������?",
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
        //        "������������� �������?", 
        //        "", 
        //        MessageBoxButtons.YesNo, 
        //        MessageBoxIcon.Question);

        //    if (result != DialogResult.Yes)
        //        eventArgs.Cancel = true;
        //}
    }
}
