using System;
using System.Windows;

namespace motitask.Windows.LPR;

public partial class EditLPR : Window
{
    private readonly motitask.LPR _lpr;
    public event Action OnEdited;
    
    private DBContext DBContext => ServiceLocator.DBContext;

    public EditLPR(motitask.LPR lpr)
    {
        InitializeComponent();
        _lpr = lpr;
        nameBox.Text = lpr.L_name;
        rangeBox.Text = lpr.L_range.ToString();
    }

    private void SaveClick(object sender, RoutedEventArgs e)
    {
        _lpr.L_name = nameBox.Text;
        _lpr.L_range = Convert.ToInt32(rangeBox.Text);
        
        DBContext.SaveChanges();
        OnEdited?.Invoke();
        this.Close();
    }

    private void CancelClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}