using System.Windows;

namespace motitask.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void OpenAlternative(object sender, RoutedEventArgs e)
        {
            var window = new Alternatives();
            window.Show();
        } 
        
        private void OpenCriterion(object sender, RoutedEventArgs e)
        {
            var window = new Criterias.Criterias();
            window.Show();
        }
        
        private void OpenMark(object sender, RoutedEventArgs e)
        {
            var window = new Marks.Marks();
            window.Show();
        }
        
        private void OpenLPR(object sender, RoutedEventArgs e)
        {
            var window = new LPR.LPRs();
            window.Show();
        }
        
        private void OpenResult(object sender, RoutedEventArgs e)
        {
        }
        
        private void OpenVector(object sender, RoutedEventArgs e)
        {
            var window = new Vectors.Vectors();
            window.Show();
        }

        private void AddDrone(object sender, RoutedEventArgs e)
        {
            var window = new AddDrone.AddDrone();
            window.Show();
        }
    }
}