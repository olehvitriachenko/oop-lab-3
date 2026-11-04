using System.Text;
using PalindromeApp;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

var checker = new PalindromeChecker(new InputValidator());

// Режим тестування: dotnet run -- --test
if (args.Contains("--test"))
{
    bool allPassed = new PalindromeTests(checker).RunAll();
    return allPassed ? 0 : 1;
}

Console.WriteLine("=== Перевірка слова на паліндром ===");
Console.WriteLine("Введіть слово або фразу (порожній рядок або \"вихід\" — завершити).");

while (true)
{
    Console.Write("\nСлово: ");
    string? input = Console.ReadLine();

    if (input == null || input.Trim().Equals("вихід", StringComparison.OrdinalIgnoreCase) || input.Trim() == "")
    {
        Console.WriteLine("До побачення!");
        return 0;
    }

    try
    {
        Console.WriteLine(checker.IsPalindrome(input)
            ? $"\"{input}\" — це паліндром."
            : $"\"{input}\" — це НЕ паліндром.");
    }
    catch (InvalidInputException ex)
    {
        Console.WriteLine($"Помилка: {ex.Message}");
    }
}
