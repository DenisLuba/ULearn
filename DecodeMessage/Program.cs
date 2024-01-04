namespace DecodeMessage
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            const string text = @"решИла нЕ Упрощать и зашифРОВАтЬ Все послаНИЕ
                                дАже не Старайся нИЧЕГО у тЕбя нЕ получится с расшифРОВкой
                                Сдавайся НЕ твоего ума Ты не споСОбЕн Но может быть
                                если особенно упорно подойдешь к делу
                                
                                будет Трудно конечнО
                                Код ведЬ не из простых
                                очень ХОРОШИЙ код\nто у тебя все получится
                                и я буДу Писать тЕбЕ еще
                                
                                чао";

            Console.WriteLine(DecodeMessage(text.Split('\n')));
        }

        private static string DecodeMessage(string[] lines) => lines
            .SelectMany(line => line.Split(' '))
            .Where(word => word.Length > 0 && Char.IsUpper(word[0]))
            .Reverse()
            .Aggregate((a, b) => $"{a} {b}");
    }
}