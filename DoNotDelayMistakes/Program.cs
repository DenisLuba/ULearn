internal class Program
{
    public static void Main()
    {
        WriteStudent();
    }
    private static void WriteStudent()
    {
        // ReadName считает неизвестно откуда имя очередного студента
        var student = new Student { Name = "Boris" };
        Console.WriteLine("student " + FormatStudent(student));
    }

    private static string FormatStudent(Student student)
    {
        return student.Name.ToUpper();
    }
}

public class Student
{

    private string? name;
    public string Name
    {
        get { return name ?? throw new ArgumentException(); }
        set { name = value; }
    }
}