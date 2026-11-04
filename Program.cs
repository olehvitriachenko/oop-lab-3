using System.Text;
using Avalonia;

namespace PalindromeApp;

internal static class Program
{
    [STAThread]
    public static int Main(string[] args)
    {
        // Режим тестування без вікна: dotnet run -- --test
        if (args.Contains("--test"))
        {
            Console.OutputEncoding = Encoding.UTF8;
            var checker = new PalindromeChecker(new InputValidator());
            return new PalindromeTests(checker).RunAll() ? 0 : 1;
        }

        return BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp() =>
        AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
