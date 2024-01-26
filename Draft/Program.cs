namespace Draft

{
    internal class Program
    {
        public static void Main()
        {
            //var arg1 = "100500";
            //Console.Write(arg1.ToInt() + "42".ToInt()); // 100542

            //foreach (var fileInfo in GetFiles("D:\\Movies"))
            //{
            //    Console.WriteLine(fileInfo.Name);      
            //}
            //Console.WriteLine();

            var list = new List<FileInfo>()
            {
                new("/A/1.mp3"),
                new("/B/2.mp3"),
                new("/C/3.mp3")
            };
            foreach (var directory in GetAlbums1(GetFiles(@"D:\Movies")))
            //foreach (var directory in GetAlbums(list))
            {
                Console.WriteLine(directory.Name);
            }
        }

        public static List<DirectoryInfo> GetAlbums(List<FileInfo> files)
            => files.Where(file => file.Extension is ".wav" or ".mp3")
                .Select(file => file.Directory)!
                .ToHashSet<DirectoryInfo>(new Comparer())
                .ToList();

        public static List<DirectoryInfo> GetAlbums1(List<FileInfo> files)
            => files.Where(file => file.Extension is ".avi" or ".mp3")
                .Select(file => file.Directory)!
                //.GroupBy(directory => directory?.Name)
                //.Select(group => group.First())
                .ToHashSet<DirectoryInfo>(new Comparer())
                .ToList()!;

        class Comparer : IEqualityComparer<DirectoryInfo>
        {
            public bool Equals(DirectoryInfo x, DirectoryInfo y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.FullName == y.FullName;
            }

            public int GetHashCode(DirectoryInfo obj)
            {
                return obj.FullName.GetHashCode();
            }
        }
        private static List<FileInfo> GetFiles(string directory) => new DirectoryInfo(directory).EnumerateFiles("*.*", SearchOption.AllDirectories).ToList();
}

static class StringExtensions
{
    public static int ToInt(this string number)
    {
        int.TryParse(number, out var x);
        return x;
    }
}
}
