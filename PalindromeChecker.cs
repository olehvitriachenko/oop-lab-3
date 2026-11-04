namespace PalindromeApp;

/// <summary>Визначає, чи є слово паліндромом (без урахування регістру та розділових знаків).</summary>
public class PalindromeChecker
{
    private readonly InputValidator _validator;

    public PalindromeChecker(InputValidator validator)
    {
        _validator = validator;
    }

    public bool IsPalindrome(string? input)
    {
        string text = _validator.Normalize(input);

        // Порівнюємо символи з обох кінців, рухаючись до середини
        for (int left = 0, right = text.Length - 1; left < right; left++, right--)
        {
            if (text[left] != text[right])
                return false;
        }
        return true;
    }
}
