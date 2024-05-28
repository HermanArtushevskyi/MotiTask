using System;
using System.Windows;

namespace motitask.Windows.Vectors;

public partial class AddVector : Window
{
    public event Action OnAdded;
    
    private DBContext _dbContext => ServiceLocator.DBContext;
    
    public AddVector()
    {
        InitializeComponent();
    }

    private void AddClick(object sender, RoutedEventArgs e)
    {
        var vector = new Vector
        {
            A_id = Convert.ToInt32(aBox.Text),
            M_id = Convert.ToInt32(mBox.Text)
        };
        
        _dbContext.Add(vector);
        _dbContext.SaveChanges();
        OnAdded?.Invoke();
        this.Close();
    }

    private void CancelClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}