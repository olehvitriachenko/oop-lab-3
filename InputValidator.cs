namespace PalindromeApp;

/// <summary>Помилка некоректного введення користувача.</summary>
public class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message) { }
}

/// <summary>Перевіряє та нормалізує введені дані.</summary>
public class InputValidator
{
    /// <summary>
    /// Перевіряє введення і повертає лише літери та цифри в нижньому регістрі.
    /// </summary>
    /// <exception cref="InvalidInputException">Порожній ввід або немає жодної літери чи цифри.</exception>
    public string Normalize(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new InvalidInputException("Введення порожнє. Будь ласка, введіть слово.");

        string normalized = new string(input.Where(char.IsLetterOrDigit).ToArray()).ToLowerInvariant();

        if (normalized.Length == 0)
            throw new InvalidInputException("Введення не містить жодної літери чи цифри.");

        return normalized;
    }
}
