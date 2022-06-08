namespace PcControl {
    public static class Extension {
        public static string Replace<T>(this string source, string placeholder, T value) {
            return source.Replace(placeholder, value.ToString());
        }
    }
}
