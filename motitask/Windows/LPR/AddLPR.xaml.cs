using System;
using System.Windows;

namespace motitask.Windows.LPR;

public partial class AddLPR : Window
{
    public event Action OnAdded;
    
    private DBContext DBContext => ServiceLocator.DBContext;

    public AddLPR()
    {
        InitializeComponent();
    }

    private void AddClick(object sender, RoutedEventArgs e)
    {
        motitask.LPR lpr = new()
        {
            L_name = nameBox.Text,
            L_range = Convert.ToInt32(rangeBox.Text)
        };
        
        DBContext.Add(lpr);
        DBContext.SaveChanges();
        OnAdded?.Invoke();
        this.Close();
    }

    private void CancelClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}