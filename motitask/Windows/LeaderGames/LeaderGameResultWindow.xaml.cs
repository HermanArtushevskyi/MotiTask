using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace motitask.Windows.LeaderGames;

public partial class LeaderGameResultWindow : Window
{
    private DBContext DbContext => ServiceLocator.DBContext;
    private LeaderGameModel LeaderGameModel => ServiceLocator.LeaderGameModel;
    private List<ResultViewModel> ResultViewModels { get; set; }
    
    public LeaderGameResultWindow()
    {
        InitializeComponent();
        FillWindow();
        AddDataToDB();
    }

    private void FillWindow()
    {
        ResultViewModels = new List<ResultViewModel>();

        foreach (KeyValuePair<int,int> handledDrone in LeaderGameModel.HandledDrones)
        {
            ResultViewModel resultViewModel = new ResultViewModel();
            resultViewModel.Name = DbContext.Alternatives.ToList().Find(a => a.A_id == handledDrone.Key).A_name;
            resultViewModel.Score = handledDrone.Value;
            resultViewModel.LPRName = DbContext.LPRs.ToList().Find(lpr => lpr.L_id == LeaderGameModel.LPRId).L_name;
            
            resultViewModel.Range = GetRange(handledDrone.Key);

            ResultViewModels.Add(resultViewModel);
        }
        
        resultGrid.ItemsSource = ResultViewModels;
    }

    private int GetRange(int droneId)
    {
        var sortedDrones = LeaderGameModel.HandledDrones.OrderByDescending(d => d.Value).ToList();
        return sortedDrones.FindIndex(d => d.Key == droneId) + 1;
    }

    private void AddDataToDB()
    {
        var resultForLPR = DbContext.Results.ToList().Where(r => r.L_id == LeaderGameModel.LPRId).ToList();
        foreach (var result in resultForLPR)
        {
            DbContext.Results.Remove(result);
        }
        
        foreach (var handledDrone in LeaderGameModel.HandledDrones)
        {
            Result result = new Result();
            result.L_id = LeaderGameModel.LPRId;
            result.A_id = handledDrone.Key;
            result.L_range = GetRange(handledDrone.Key);
            
            DbContext.Results.Add(result);
        }
        
        DbContext.SaveChanges();
    }
}