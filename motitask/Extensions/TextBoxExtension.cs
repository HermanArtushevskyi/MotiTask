using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace motitask.Extensions;

public static class TextBoxExtension
{
    private static readonly Regex _regex = new Regex("^[0-9]+$");
    
    public static bool IsTextNumeric(this TextBox textBox)
    {
        string text = textBox.Text;
        return !string.IsNullOrEmpty(text) && !_regex.IsMatch(text);
    }
}