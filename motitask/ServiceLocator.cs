using motitask.Services;

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
}