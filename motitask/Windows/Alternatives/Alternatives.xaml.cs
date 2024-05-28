using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace motitask.Windows;

public partial class Alternatives : Window
{
    private DBContext DBContext => ServiceLocator.DBContext;
    private List<Alternative> AlternativesList { get; set; }
    
    public Alternatives()
    {
        InitializeComponent();
        AlternativesList = DBContext.Alternatives.ToList();
    }

    private void Alternatives_OnLoaded(object sender, RoutedEventArgs e)
    {
        dataG.ItemsSource = AlternativesList;
    }

    private void OpenNewAlternative(object sender, RoutedEventArgs e)
    {
        var newAlternative = new NewAlternative();
        newAlternative.OnAdded += Refresh;
        newAlternative.ShowDialog();
    }

    private void DeleteAlternatiive(object sender, RoutedEventArgs e)
    {
        var alternative = (Alternative) dataG.SelectedItem;
        DBContext.Remove(alternative);
        DBContext.SaveChanges();
        Refresh();
    }

    private void EditAlternative(object sender, RoutedEventArgs e)
    {
        var alternative = (Alternative) dataG.SelectedItem;
        var editAlternative = new EditAlternative(alternative);
        editAlternative.OnEdited += Refresh;
        editAlternative.ShowDialog();
    }

    private void Refresh()
    {
        AlternativesList = DBContext.Alternatives.ToList();
        dataG.ItemsSource = AlternativesList;
    }
}