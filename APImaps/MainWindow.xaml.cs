using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using APImaps.DAL;
namespace APImaps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DALPlayer dal=new DALPlayer();
        DALRoute dalro = new DALRoute();
        DALRapidity dalr = new DALRapidity();
        DALTrust dalt = new DALTrust();
        DALStatus dals = new DALStatus();
        public MainWindow()
        {
            InitializeComponent();
            listBoxUserPeople.ItemsSource = dal.GetPlayers();
            GridHello.Visibility = Visibility.Visible;
            GridButton.Visibility = Visibility.Hidden;
            ChangeScreen("");
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                GridHello.Visibility = Visibility.Hidden;
                GridButton.Visibility = Visibility.Visible;
                ChangeScreen("people");
            };
        }
        private void ButtonPeople_Click(object sender, RoutedEventArgs e)
        {
            ChangeScreen("people");
        }
        private void ButtonRoute_Click(object sender, RoutedEventArgs e)
        {
            ChangeScreen("route");
        }
        private void ButtonPDF_Click(object sender, RoutedEventArgs e)
        {
            ChangeScreen("pdf");
        }
        private void ButtonLeave_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void ChangeScreen(string name)
        {
            switch (name)
            {
                case "people":
                    GridPeople.Visibility = Visibility.Visible;
                    GridRoute.Visibility = Visibility.Hidden;
                    GridPdf.Visibility = Visibility.Hidden;
                    break;
                case "route":
                    GridPeople.Visibility = Visibility.Hidden;
                    GridPdf.Visibility = Visibility.Hidden;
                    GridRoute.Visibility = Visibility.Visible;
                    break;
                case "pdf":
                    GridPeople.Visibility = Visibility.Hidden;
                    GridPdf.Visibility = Visibility.Visible;
                    GridRoute.Visibility = Visibility.Hidden;
                    break;
                default:
                    GridPeople.Visibility = Visibility.Hidden;
                    GridPdf.Visibility = Visibility.Hidden;
                    GridRoute.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void ListBox_SelectionChanged(object sender, MouseButtonEventArgs e)
        {
            Route route = (Route)ListBoxRoutesPeople.SelectedItem;
            if(route.status.idstatus==1)
            {
                Status s=dals.GetStatus(2);
                dalro.ChangeStatus(s,route);
                }
            else if(route.status.idstatus == 2)
            {
                Status s = dals.GetStatus(1);
                dalro.ChangeStatus(s, route);
            }
        }

        private void AddPlayer(object sender, RoutedEventArgs e)
        {
            Adduser newus = new Adduser();
            newus.Show();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            listBoxUserPeople.ItemsSource = dal.GetPlayers();
        }
    }

}
