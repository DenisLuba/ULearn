namespace OptimizeContacts
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>()
            {
                "unknown:email@mail.com",
                "Sasha:sasha1995@sasha.ru",
                "Tom:Tom1998@gmail.com",
                "Sam:sami@mail.ru",
                "Bill:bibb@google.com",
                "Bob:Bobb33@mail.ru",
                "C:CiDed@gmail.com",
                "Mariya:Masha333@mail.ru",
                "Franz:Kafka@gmail.com",
                "Fiona:Fialka1999@mail.ru",
                "Fiona:Fiona333@gmail.com",
                "Fill:Spencer123@google.com",
                "s:sasok25@mail.ru",
                "sasha1995:sasha1995@sasha.ru",
                "sasha:alex99@mail.ru",
                "s1:ssok@mail.ru",
                "sania:shurik2020@google.com",
                "sS:sasok25@mail.ru",
                "vasia:Vasek12@mail.re"
            };
            var dictionary = OptimizeContacts(list);
            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key + " -> " + String.Join(",", item.Value));
            }
        }

        private static Dictionary<string, List<string>> OptimizeContacts(List<string> contacts) => contacts
            .GroupBy(contact => String.Join("", contact.Take(2).Where(ch => ch != ':')))
            .ToDictionary(
                contactEmails => contactEmails.Key,
                contactEmails => contactEmails.ToList()
            );
    }
}