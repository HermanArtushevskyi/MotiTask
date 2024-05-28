using System;
using System.Windows;

namespace motitask.Windows;

public partial class EditAlternative : Window
{
    public event Action OnEdited;
    
    private readonly DBContext _dbContext = ServiceLocator.DBContext;
    private readonly Alternative _alternative;

    public EditAlternative(Alternative alternative)
    {
        _alternative = alternative;
        InitializeComponent();
        NameBox.Text = _alternative.A_name;
    }

    private void SaveClick(object sender, RoutedEventArgs e)
    {
        _alternative.A_name = NameBox.Text;
        _dbContext.SaveChanges();
        OnEdited?.Invoke();
        this.Close();
    }

    private void CancelClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}