using System.Windows;
using motitask.Services;

namespace motitask.Windows.AddDrone;

public partial class AddDrone : Window
{
    private DBContext _dbContext => ServiceLocator.DBContext;
    private DroneCreator _droneCreator => ServiceLocator.DroneCreator;
    
    public AddDrone()
    {
        InitializeComponent();
    }

    private void AddClicked(object sender, RoutedEventArgs e)
    {
        _droneCreator.CreateDrone(_dbContext, nameBox.Text, int.Parse(distanceBox.Text), int.Parse(priceBox.Text), int.Parse(maxPayloadBox.Text), int.Parse(flightTimeBox.Text), int.Parse(weightBox.Text));
    }

    private void CancelClicked(object sender, RoutedEventArgs e)
    {
        Close();
    }
}