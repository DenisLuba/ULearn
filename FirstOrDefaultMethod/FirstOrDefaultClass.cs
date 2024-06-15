using System.Collections.Generic;

namespace FirstOrDefaultMethod
{
    public static class FirstOrDefaultClass
    {
        public static T? MyFirstOrDefault<T>
            (this IEnumerable<T> source, Func<T, bool> filter)
        {
            foreach (var i in source)
                if (filter(i)) return i;

            return default;
        }
    }
}
