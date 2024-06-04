using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace motitask.Windows.LeaderGames;

public partial class LeaderGameStepWindow : Window
{
    private DBContext DbContext => ServiceLocator.DBContext;
    private LeaderGameModel LeaderGameModel => ServiceLocator.LeaderGameModel;
    private List<CriteriaData> LeaderTableData { get; set; }
    private List<CriteriaData> VariantTableData { get; set; }
    
    public LeaderGameStepWindow()
    {
        InitializeComponent();
        FillWindow();
    }

    private void SelectLeader(object sender, RoutedEventArgs e)
    {
        if (LeaderGameModel.VariantId == LeaderGameModel.MaxDroneId) Finish(true);

        else
        {
            LeaderGameModel.HandledDrones.Add(LeaderGameModel.VariantDBId, 0);
            LeaderGameModel.VariantId++;
            LeaderGameModel.VariantDBId = DbContext.Alternatives.ToList()[LeaderGameModel.VariantId].A_id;
            LeaderGameModel.LeaderPoints++;

            FillWindow();
        }
    }

    private void SelectVariant(object sender, RoutedEventArgs e)
    {
        if (LeaderGameModel.VariantId == LeaderGameModel.MaxDroneId) Finish(false);
        else
        {
            LeaderGameModel.HandledDrones.Add(LeaderGameModel.LeaderDBId, LeaderGameModel.LeaderPoints);
            LeaderGameModel.LeaderId = LeaderGameModel.VariantId;
            LeaderGameModel.LeaderDBId = LeaderGameModel.VariantDBId;
            LeaderGameModel.LeaderPoints++;
            LeaderGameModel.VariantId++;
            LeaderGameModel.VariantDBId = DbContext.Alternatives.ToList()[LeaderGameModel.VariantId].A_id;

            FillWindow();
        }
    }

    private void Finish(bool isLeaderLast)
    {
        if (isLeaderLast)
        {
            LeaderGameModel.HandledDrones.Add(LeaderGameModel.LeaderDBId, LeaderGameModel.LeaderPoints);
            LeaderGameModel.HandledDrones.Add(LeaderGameModel.VariantDBId, 0);
        }
        else
        {
            LeaderGameModel.HandledDrones.Add(LeaderGameModel.LeaderDBId, LeaderGameModel.LeaderPoints);
            LeaderGameModel.HandledDrones.Add(LeaderGameModel.VariantDBId, LeaderGameModel.LeaderPoints + 1);
        }
        
        var resWnd = new LeaderGameResultWindow();
        resWnd.Show();
        this.Close();
    }

    private void FillWindow()
    {
        leaderName.Text = DbContext.Alternatives.ToList()[LeaderGameModel.LeaderId].A_name;
        variantName.Text = DbContext.Alternatives.ToList()[LeaderGameModel.VariantId].A_name;
        
        var criteria = DbContext.Criteria.ToList();
        var marks = DbContext.Marks.ToList();
        var vectors = DbContext.Vectors.ToList();
        
        LeaderTableData = new List<CriteriaData>();
        VariantTableData = new List<CriteriaData>();
        
        var leaderVectors = vectors.Where(v => v.A_id == LeaderGameModel.LeaderDBId).ToList();

        foreach (Vector leaderVector in leaderVectors)
        {
            var mark = marks.Where(m => m.M_id == leaderVector.M_id).First();
            var criterion = criteria.Where(c => c.C_id == mark.C_id).First();
            
            LeaderTableData.Add(new CriteriaData
            {
                Name = criterion.C_name,
                Value = mark.M_name
            });
        }
        
        var variantVectors = vectors.Where(v => v.A_id == LeaderGameModel.VariantDBId).ToList();
        
        foreach (Vector variantVector in variantVectors)
        {
            var mark = marks.Where(m => m.M_id == variantVector.M_id).First();
            var criterion = criteria.Where(c => c.C_id == mark.C_id).First();
            
            VariantTableData.Add(new CriteriaData
            {
                Name = criterion.C_name,
                Value = mark.M_name
            });
        }
        
        leaderTable.ItemsSource = LeaderTableData;
        variantTable.ItemsSource = VariantTableData;
    }
}