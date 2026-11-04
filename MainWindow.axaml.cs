using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace PalindromeApp;

/// <summary>Головне вікно: введення слова, результат перевірки та історія.</summary>
public partial class MainWindow : Window
{
    private static readonly IBrush SuccessBackground = new SolidColorBrush(Color.FromRgb(223, 246, 228));
    private static readonly IBrush FailBackground = new SolidColorBrush(Color.FromRgb(253, 236, 220));
    private static readonly IBrush ErrorBackground = new SolidColorBrush(Color.FromRgb(253, 225, 225));
    private static readonly IBrush NeutralBackground = new SolidColorBrush(Color.FromRgb(243, 243, 243));

    private readonly InputValidator _validator = new();
    private readonly PalindromeChecker _checker;
    private readonly ObservableCollection<string> _history = new();

    public MainWindow()
    {
        InitializeComponent();
        _checker = new PalindromeChecker(_validator);

        HistoryList.ItemsSource = _history;
        CheckButton.Click += OnCheckClick;
        ClearButton.Click += (_, _) => _history.Clear();
    }

    /// <summary>Обробник кнопки: перевірити введене слово та показати результат.</summary>
    private void OnCheckClick(object? sender, RoutedEventArgs e)
    {
        string? input = WordInput.Text;
        try
        {
            bool isPalindrome = _checker.IsPalindrome(input);
            string word = input!.Trim();

            ResultText.Text = isPalindrome ? $"«{word}» — це паліндром ✓" : $"«{word}» — це НЕ паліндром ✗";
            DetailText.Text = $"Після нормалізації: «{_validator.Normalize(input)}»";
            ResultBorder.Background = isPalindrome ? SuccessBackground : FailBackground;
            _history.Insert(0, $"{(isPalindrome ? "✓" : "✗")}  {word}");
        }
        catch (InvalidInputException ex)
        {
            ResultText.Text = "Помилка введення";
            DetailText.Text = ex.Message;
            ResultBorder.Background = ErrorBackground;
        }
        catch (Exception ex)
        {
            // Непередбачена помилка не повинна закривати програму
            ResultText.Text = "Неочікувана помилка";
            DetailText.Text = ex.Message;
            ResultBorder.Background = NeutralBackground;
        }

        WordInput.SelectAll();
        WordInput.Focus();
    }
}
