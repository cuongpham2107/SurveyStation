namespace Common {
    public class Helper {
        public static void Print(string message, ConsoleColor color = ConsoleColor.White, bool reset = false) {
            Console.ForegroundColor = color;
            Console.Write(message);
            if (reset) Console.ResetColor();
        }

        public static void PrintLine(string message, ConsoleColor color = ConsoleColor.White, bool reset = false) {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            if (reset) Console.ResetColor();
        }

        public static async Task PrintAsync(string message, ConsoleColor color = ConsoleColor.White, bool reset = false) {
            await Task.Run(() => {
                Console.ForegroundColor = color;
                Console.Write(message);
                if (reset) Console.ResetColor();
            });
        }

        public static async Task PrintLineAsync(string message, ConsoleColor color = ConsoleColor.White, bool reset = false) {
            await Task.Run(() => {
                Console.ForegroundColor = color;
                Console.WriteLine(message);
                if (reset) Console.ResetColor();
            });
        }
    }
}