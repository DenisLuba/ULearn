using System.Text;

namespace DecodeMessage2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] commands =
            {
                "push Привет! Это снова я! Пока!",
                "pop 5",
                "push Как твои успехи? Плохо?",
                "push qwertyuiop",
                "push 1234567890",
                "pop 26"
            };

            Console.WriteLine(ApplyCommands(commands));
        }

        private static string ApplyCommands(string[] commands)
        {
            var builder = new StringBuilder();
            foreach (var line in commands)
            {
                if (line.StartsWith("push "))
                {
                    builder.Append(line.Replace("push ", ""));
                }
                else if (line.StartsWith("pop "))
                {
                    var numberForDeleting = int.Parse(line.Replace("pop ", "").Trim());
                    if (builder.Length >= numberForDeleting)
                        builder.Remove(builder.Length - numberForDeleting, numberForDeleting);
                }
            }

            return builder.ToString();
        }
    }
}