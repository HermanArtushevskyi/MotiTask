using System;
using System.Numerics;
using System.Windows;

namespace motitask.Windows.Vectors;

public partial class EditVector : Window
{
    public event Action OnEdited;
    
    private DBContext _dbContext => ServiceLocator.DBContext;
    private Vector _vector;
    
    public EditVector(Vector vector)
    {
        InitializeComponent();
        _vector = vector;
        aBox.Text = vector.A_id.ToString();
        mBox.Text = vector.M_id.ToString();
    }

    private void EditClick(object sender, RoutedEventArgs e)
    {
        _vector.A_id = Convert.ToInt32(aBox.Text);
        _vector.M_id = Convert.ToInt32(mBox.Text);
        _dbContext.SaveChanges();
        OnEdited?.Invoke();
        this.Close();
    }

    private void CancelClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}