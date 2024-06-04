using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LPR = motitask.LPR;

namespace motitask.Windows.LeaderGames;

public partial class LeaderGamesWindow : Window
{
    private DBContext DbContext => ServiceLocator.DBContext;
    private Dictionary<string, int> _lprs = new();
    
    public LeaderGamesWindow()
    {
        InitializeComponent();

        var lprs = DbContext.LPRs.ToList();
        foreach(motitask.LPR lpr in lprs)
        {
            _lprs.Add(lpr.L_name, lpr.L_id);
        }
        
        lprBox.ItemsSource = _lprs.Keys;
        lprBox.SelectedItem = _lprs.Keys.First();
    }

    private void BackBtnClicked(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void StartBtnClick(object sender, RoutedEventArgs e)
    {
        ServiceLocator.LeaderGameModel = new LeaderGameModel();
        ServiceLocator.LeaderGameModel.LPRId = _lprs[lprBox.SelectedItem.ToString()];
        ServiceLocator.LeaderGameModel.LeaderId = 0;
        ServiceLocator.LeaderGameModel.LeaderDBId = DbContext.Alternatives.ToList()[0].A_id;
        ServiceLocator.LeaderGameModel.LeaderPoints = 0;
        ServiceLocator.LeaderGameModel.VariantId = 1;
        ServiceLocator.LeaderGameModel.VariantDBId = DbContext.Alternatives.ToList()[1].A_id;
        ServiceLocator.LeaderGameModel.HandledDrones = new Dictionary<int, int>();
        ServiceLocator.LeaderGameModel.MaxDroneId = DbContext.Alternatives.Count() - 1;
        
        var leaderGameStepWindow = new LeaderGameStepWindow();
        leaderGameStepWindow.Show();
    }
}