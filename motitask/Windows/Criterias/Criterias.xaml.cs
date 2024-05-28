using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace motitask.Windows.Criterias;

public partial class Criterias : Window
{
    private DBContext DBContext = ServiceLocator.DBContext;
    private List<Criterion> Criterions = new();

    public Criterias()
    {
        InitializeComponent();
        Criterions = DBContext.Criteria.ToList();
    }

    private void Criterias_OnLoaded(object sender, RoutedEventArgs e)
    {
        dataG.ItemsSource = Criterions;
    }

    private void AddBtnClick(object sender, RoutedEventArgs e)
    {
        var newCriterion = new AddCriteria();
        newCriterion.OnAdded += Refresh;
        newCriterion.ShowDialog();
    }

    private void DeleteBtnClick(object sender, RoutedEventArgs e)
    {
        var criterion = (Criterion) dataG.SelectedItem;
        DBContext.Remove(criterion);
        DBContext.SaveChanges();
        Refresh();
    }

    private void EditBtnClick(object sender, RoutedEventArgs e)
    {
        var criterion = (Criterion) dataG.SelectedItem;
        var editCriterion = new EditCriteria(criterion);
        editCriterion.OnEdited += Refresh;
        editCriterion.ShowDialog();
    }

    private void Refresh()
    {
        Criterions = DBContext.Criteria.ToList();
        dataG.ItemsSource = Criterions;
    }
}