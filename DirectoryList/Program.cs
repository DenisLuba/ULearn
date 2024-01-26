foreach (var fileInfo in GetFiles("D:\\Movies"))
{
    Console.WriteLine(fileInfo.Name);
}
Console.WriteLine();

foreach (var directory in GetAlbums1(GetFiles(@"D:\Movies")))
{
    Console.WriteLine(directory.Name);
}

return;


static List<DirectoryInfo> GetAlbums1(IEnumerable<FileInfo> files)
    => files.Where(file => file.Extension is ".avi" or ".mp3")
        .Select(file => file.Directory)!
        //.GroupBy(directory => directory?.Name)
        //.Select(group => group.First())
        .ToHashSet<DirectoryInfo>(new Comparer())
        .ToList();


static List<FileInfo> GetFiles(string directory) => new DirectoryInfo(directory).EnumerateFiles("*.*", SearchOption.AllDirectories).ToList();

internal class Comparer : IEqualityComparer<DirectoryInfo>
{
    public bool Equals(DirectoryInfo? x, DirectoryInfo? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.FullName == y.FullName;
    }

    public int GetHashCode(DirectoryInfo obj)
    {
        return obj.FullName.GetHashCode();
    }
}



