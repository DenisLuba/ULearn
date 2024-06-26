namespace MyFormsTableGame
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var game = new GameModel(5);
            Application.Run(new MyForm(game) { ClientSize = new Size(300, 300) });
        }
    }
}