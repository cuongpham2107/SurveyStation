using System.Text;

namespace Common {
    public static class Extension {
        public static string Replace<T>(this string source, string placeholder, T value) {
            return source.Replace(placeholder, value.ToString());
        }

        public static string GetString(this byte[] bytes) {
            return Encoding.UTF8.GetString(bytes);
        }

        public static byte[] GetBytes(this string source) {
            return Encoding.UTF8.GetBytes(source);
        }
    }
}
