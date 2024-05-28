using System;
using System.Windows;

namespace motitask.Windows.Marks;

public partial class AddMark : Window
{
    public event Action OnAdded;
    
    private DBContext DbContext = ServiceLocator.DBContext;
    
    public AddMark()
    {
        InitializeComponent();
    }

    private void AddBtnClick(object sender, RoutedEventArgs e)
    {
        var Mark = new Mark
        {
            C_id = Convert.ToInt32(criterionIdBox.Text),
            M_name = nameBox.Text,
            M_range = int.Parse(rangeBox.Text),
            M_num = int.Parse(numBox.Text),
            M_norm = double.Parse(normBox.Text)
        };
        
        DbContext.Marks.Add(Mark);
        DbContext.SaveChanges();
        OnAdded?.Invoke();
        Close();
    }

    private void CancelBtnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}