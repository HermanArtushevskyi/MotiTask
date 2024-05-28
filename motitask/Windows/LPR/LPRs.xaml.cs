using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace motitask.Windows.LPR;

public partial class LPRs : Window
{
    private DBContext DBContext => ServiceLocator.DBContext;
    private List<motitask.LPR> LPRList { get; set; }
    
    public LPRs()
    {
        InitializeComponent();
        LPRList = DBContext.LPRs.ToList();
    }

    private void LPRs_OnLoaded(object sender, RoutedEventArgs e)
    {
        dataG.ItemsSource = LPRList;
    }

    private void AddBtnClick(object sender, RoutedEventArgs e)
    {
        var window = new AddLPR();
        window.OnAdded += Refresh;
        window.Show();
    }

    private void DeleteBtnClick(object sender, RoutedEventArgs e)
    {
        var lpr = (motitask.LPR) dataG.SelectedItem;
        DBContext.Remove(lpr);
        DBContext.SaveChanges();
        Refresh();
    }

    private void EditBtnClick(object sender, RoutedEventArgs e)
    {
        var lpr = (motitask.LPR) dataG.SelectedItem;
        var window = new EditLPR(lpr);
        window.OnEdited += Refresh;
        window.Show();
    }

    private void Refresh()
    {
        LPRList = DBContext.LPRs.ToList();
        dataG.ItemsSource = LPRList;
    }
}