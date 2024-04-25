internal class Program
{
    public static void Main()
    {

    }

    public static void Check()
    {
        var book = new Book();
        book.Title = "Structure and interpretation of computer programs";
        Console.WriteLine(book.Title);
    }
}

public class Book
{
    public string Title { get; set; }
}