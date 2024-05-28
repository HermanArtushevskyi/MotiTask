using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using motitask.Extensions;

namespace motitask.Windows.Criterias;

public partial class AddCriteria : Window
{
    private DBContext DbContext => ServiceLocator.DBContext;
    public event Action OnAdded;
    
    public AddCriteria()
    {
        InitializeComponent();
    }

    private void AddBtnClick(object sender, RoutedEventArgs e)
    {
        Criterion criterion = new()
        {
            C_name = nameBox.Text,
            C_range = int.Parse(rangeBox.Text),
            C_weight = double.Parse(weightBox.Text),
            C_type = typeBox.Text,
            optim_type = optimtypeBox.Text
        };
        DbContext.Criteria.Add(criterion);
        DbContext.SaveChanges();
        OnAdded?.Invoke();
        this.Close();
    }

    private void CancelBtnClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}