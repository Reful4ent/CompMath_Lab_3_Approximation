using System.Windows;

namespace CompMath_Lab3_Approximation.View;

public partial class ErrorWindow : Window
{
    private readonly Dictionary<int, string> errors = new()
    {
        { 0, "Присутствует ошибка!\n" +
             "Возможные неисправности:" +
             "\n1. Количество X != Y\n" +
             "2. В таблице X должны идти по возрастанию!\n" +
             "3. В таблице не может быть повторяющихся X\n" +
             "Исправьте ошибки и попробуйте снова!!!"},
        { 1, "Таблица не была задана!!"}
    };
    public ErrorWindow(int errorKey)
    {
        InitializeComponent();
        Error__Block.Text = errors[errorKey];
    }
}