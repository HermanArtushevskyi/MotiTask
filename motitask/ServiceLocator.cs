using motitask.Services;
using motitask.Windows.LeaderGames;

namespace motitask;

public static class ServiceLocator
{
    private static DBContext _dbContext;
    public static DBContext DBContext
    {
        get { return _dbContext ??= new DBContext(); }
    }
    
    private static DroneCreator _droneCreator;
    public static DroneCreator DroneCreator
    {
        get { return _droneCreator ??= new DroneCreator(); }
    }
    
    private static LeaderGameModel _leaderGameModel;
    public static LeaderGameModel LeaderGameModel
    {
        get => _leaderGameModel;
        set => _leaderGameModel = value;
    }
}