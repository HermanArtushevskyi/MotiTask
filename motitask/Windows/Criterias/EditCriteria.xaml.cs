using System;
using System.Windows;

namespace motitask.Windows.Criterias;

public partial class EditCriteria : Window
{
    public event Action OnEdited;
    
    private DBContext DbContext = ServiceLocator.DBContext;
    private readonly Criterion _criterion;

    public EditCriteria(Criterion criterion)
    {
        _criterion = criterion;
        InitializeComponent();
        
        nameBox.Text = _criterion.C_name;
        rangeBox.Text = _criterion.C_range.ToString();
        weightBox.Text = _criterion.C_weight.ToString();
        typeBox.Text = _criterion.C_type;
        optimtypeBox.Text = _criterion.optim_type;
    }

    private void SaveBtnClick(object sender, RoutedEventArgs e)
    {
        _criterion.C_name = nameBox.Text;
        _criterion.C_range = int.Parse(rangeBox.Text);
        _criterion.C_weight = double.Parse(weightBox.Text);
        _criterion.C_type = typeBox.Text;
        _criterion.optim_type = optimtypeBox.Text;

        DbContext.SaveChanges();
        OnEdited?.Invoke();
        this.Close();
    }

    private void CancelBtnClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}