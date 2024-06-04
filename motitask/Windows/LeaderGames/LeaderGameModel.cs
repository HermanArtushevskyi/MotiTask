using System.Collections.Generic;

namespace motitask.Windows.LeaderGames;

public class LeaderGameModel
{
    public int LPRId { get; set; }
    public int LeaderId { get; set; }
    public int LeaderDBId { get; set; }
    public int LeaderPoints { get; set; }
    public int VariantId { get; set; }
    public int VariantDBId { get; set; }
    public Dictionary<int, int> HandledDrones { get; set; }
    public int MaxDroneId { get; set; }
}