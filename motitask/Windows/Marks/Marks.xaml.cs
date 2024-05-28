using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace motitask.Windows.Marks;

public partial class Marks : Window
{
    private DBContext _dbContext = ServiceLocator.DBContext;
    private List<Mark> _marks { get; set; }
    
    public Marks()
    {
        InitializeComponent();
        _marks = _dbContext.Marks.ToList();
        dataG.ItemsSource = _marks;
    }

    private void AddBtnClick(object sender, RoutedEventArgs e)
    {
        var window = new AddMark();
        window.OnAdded += Refresh;
        window.ShowDialog();
    }

    private void DeleteBtnClick(object sender, RoutedEventArgs e)
    {
        var mark = (Mark)dataG.SelectedItem;
        _dbContext.Marks.Remove(mark);
        _dbContext.SaveChanges();
        Refresh();
    }

    private void EditBtnClick(object sender, RoutedEventArgs e)
    {
        var mark = (Mark)dataG.SelectedItem;
        var window = new EditMark(mark);
        window.OnEdited += Refresh;
        window.ShowDialog();
    }

    private void Refresh()
    {
        _marks = _dbContext.Marks.ToList();
        dataG.ItemsSource = _marks;
    }
}