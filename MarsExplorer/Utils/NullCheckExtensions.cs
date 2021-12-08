using System;

namespace MarsExplorer.Utils
{
    public static class NullCheckExtensions
    {
        public static T NotNull<T>(this T item, string message = null)
        {
            if (item == null)
            {
                throw new ArgumentNullException(message ?? nameof(item));
            }

            return item;
        }

        public static string NotNullOrWhiteSpace(this string item, string message = null)
        {
            if (string.IsNullOrWhiteSpace(item))
            {
                throw new ArgumentNullException(message ?? nameof(item));
            }

            return item;
        }
    }
}
