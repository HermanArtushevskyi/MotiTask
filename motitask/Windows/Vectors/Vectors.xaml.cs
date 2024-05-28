using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace motitask.Windows.Vectors;

public partial class Vectors : Window
{
    private DBContext _dbContext => ServiceLocator.DBContext;
    private List<Vector> _vectorList { get; set; }
    
    public Vectors()
    {
        InitializeComponent();
        _vectorList = _dbContext.Vectors.ToList();
        Refresh();
    }

    private void AddBtnClick(object sender, RoutedEventArgs e)
    {
        var addVector = new AddVector();
        addVector.OnAdded += Refresh;
        addVector.Show();
    }

    private void DeleteBtnClick(object sender, RoutedEventArgs e)
    {
        var vector = (Vector) dataG.SelectedItem;
        _dbContext.Remove(vector);
        _dbContext.SaveChanges();
        Refresh();
    }

    private void EditBtnClick(object sender, RoutedEventArgs e)
    {
        var vector = (Vector) dataG.SelectedItem;
        var editVector = new EditVector(vector);
        editVector.OnEdited += Refresh;
        editVector.Show();
    }

    private void Refresh()
    {
        _vectorList = _dbContext.Vectors.ToList();
        dataG.ItemsSource = _vectorList;
    }
}