using System;
using System.Windows;

namespace motitask.Windows.Marks;

public partial class EditMark : Window
{
    public event Action OnEdited;
    
    private DBContext DbContext = ServiceLocator.DBContext;
    private Mark _mark;
    
    public EditMark(Mark mark)
    {
        _mark = mark;
        InitializeComponent();
        
        criterionIdBox.Text = _mark.C_id.ToString();
        nameBox.Text = _mark.M_name;
        rangeBox.Text = _mark.M_range.ToString();
        numBox.Text = _mark.M_num.ToString();
        normBox.Text = _mark.M_norm.ToString();
    }

    private void SaveBtnClick(object sender, RoutedEventArgs e)
    {
        _mark.C_id = Convert.ToInt32(criterionIdBox.Text);
        _mark.M_name = nameBox.Text;
        _mark.M_range = int.Parse(rangeBox.Text);
        _mark.M_num = int.Parse(numBox.Text);
        _mark.M_norm = double.Parse(normBox.Text);
        
        DbContext.SaveChanges();
        OnEdited?.Invoke();
        Close();
    }

    private void CancelBtnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}