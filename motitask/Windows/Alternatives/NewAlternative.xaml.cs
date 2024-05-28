using System;
using System.Windows;

namespace motitask.Windows;

public partial class NewAlternative : Window
{
    private DBContext DBContext => ServiceLocator.DBContext;
    public event Action OnAdded;
    
    public NewAlternative()
    {
        InitializeComponent();
    }

    private void AddClick(object sender, RoutedEventArgs e)
    {
        var alternative = new Alternative
        {
            A_name = nameBox.Text
        };
        DBContext.Alternatives.Add(alternative);
        DBContext.SaveChanges();
        OnAdded?.Invoke();
        this.Close();
    }

    private void CancelClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}