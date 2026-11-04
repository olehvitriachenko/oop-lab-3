namespace PalindromeApp;

/// <summary>Набір тестових випадків для перевірки коректності PalindromeChecker.</summary>
public class PalindromeTests
{
    private readonly PalindromeChecker _checker;

    public PalindromeTests(PalindromeChecker checker)
    {
        _checker = checker;
    }

    /// <returns>true, якщо всі тести пройдено.</returns>
    public bool RunAll()
    {
        var cases = new (string Input, bool Expected)[]
        {
            ("шалаш", true),
            ("Шалаш", true),                          // великі та малі літери
            ("ПоП", true),
            ("level", true),
            ("Racecar", true),
            ("А роза упала на лапу Азора", true),     // пробіли
            ("A man, a plan, a canal: Panama!", true), // розділові знаки
            ("Was it a car or a cat I saw?", true),
            ("12321", true),
            ("а", true),                              // одна літера
            ("книга", false),
            ("Hello", false),
            ("Програма", false),
        };

        int passed = 0;
        foreach (var (input, expected) in cases)
        {
            bool actual = _checker.IsPalindrome(input);
            bool ok = actual == expected;
            if (ok) passed++;
            Console.WriteLine($"{(ok ? "[OK]  " : "[FAIL]")} \"{input}\" → {actual} (очікувалось {expected})");
        }

        // Обробка помилок: ці вводи мають викликати InvalidInputException
        foreach (string? bad in new[] { "", "   ", null, "!!!, ?" })
        {
            bool ok;
            try
            {
                _checker.IsPalindrome(bad);
                ok = false;
            }
            catch (InvalidInputException)
            {
                ok = true;
            }
            if (ok) passed++;
            Console.WriteLine($"{(ok ? "[OK]  " : "[FAIL]")} \"{bad ?? "null"}\" → помилка введення");
        }

        int total = cases.Length + 4;
        Console.WriteLine($"\nПройдено {passed} з {total} тестів.");
        return passed == total;
    }
}
