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

namespace APImaps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //DataFromSql DataUser = new DataFromSql();
        //MapsAPICreate NewMap = new MapsAPICreate();
        //Route NewRoute = new Route();
        //User NewUser = new User();
        public MainWindow()
        {
            InitializeComponent();
            //listBoxUser.ItemsSource = DataUser.DataPseudo();
            GridHello.Visibility = Visibility.Visible;
            GridButton.Visibility = Visibility.Hidden;
            GridRoute.Visibility = Visibility.Hidden;
            GridPeople.Visibility = Visibility.Hidden;
            GridPdf.Visibility = Visibility.Hidden;
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                GridHello.Visibility = Visibility.Hidden;
                GridButton.Visibility = Visibility.Visible;
                GridPeople.Visibility = Visibility.Visible;
                GridRoute.Visibility = Visibility.Hidden;
                GridPdf.Visibility = Visibility.Hidden;
            };
        }
        private void ButtonPeople_Click(object sender, RoutedEventArgs e)
        {
            GridPeople.Visibility = Visibility.Visible;
            GridRoute.Visibility = Visibility.Hidden;
            GridPdf.Visibility = Visibility.Hidden;
        }
        private void ButtonRoute_Click(object sender, RoutedEventArgs e)
        {
            GridPeople.Visibility = Visibility.Hidden;
            GridPdf.Visibility = Visibility.Hidden;
            GridRoute.Visibility = Visibility.Visible;
        }
        private void ButtonPDF_Click(object sender, RoutedEventArgs e)
        {
            GridPeople.Visibility = Visibility.Hidden;
            GridPdf.Visibility = Visibility.Visible;
            GridRoute.Visibility = Visibility.Hidden;

        }

        //private void ButtonLatLongClick(object sender, RoutedEventArgs e)
        //{
        //    String latlong = null;
        //    if (textboxLatLong.Text == "13101998")
        //    {
        //        ErreurAffiche NewErreur = new ErreurAffiche();
        //        NewErreur.labelData.Content = "mmmmh il me semble \r\n que c'est l'anniversaire \r\n de Sophie ça! :D";
        //        NewErreur.Show();
        //        Close();
        //    }
        //    else
        //    {
        //        latlong = textboxLatLong.Text;
        //        NewRoute.AddWaypoint(latlong);
        //        textboxLatLong.Clear();
        //        listBoxCoordonate.ItemsSource = null;
        //        listBoxCoordonate.ItemsSource = NewRoute.LatLong;
        //    }
        //}
        //private void ButtonAddRouteClick(object sender, RoutedEventArgs e)
        //{
        //    if (NewUser.nickname == null)
        //    {
        //        ErreurAffiche NewErreur = new ErreurAffiche();
        //        NewErreur.labelData.Content = "Veuillez d'abord sélectionner un user.";
        //        NewErreur.Show();
        //    }
        //    else
        //    {
        //        if (NewRoute.LatLong.Count == 0)
        //        {
        //            ErreurAffiche NewErreur = new ErreurAffiche();
        //            NewErreur.labelData.Content = "Veuillez d'abord ajouter des coordonnées";
        //            NewErreur.Show();
        //        }
        //        else
        //        {
        //            NewRoute.Calculate(NewUser.rapidity);
        //            DataUser.AddRoute(NewRoute, NewUser.idUser);

        //        }
        //    }
        //}
        //private void ListBoxUserSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if ((listBoxUser.SelectedValue.ToString() == "Add a player"))
        //    {
        //        NewUser WindowsUser = new WpfApp2.NewUser();
        //        WindowsUser.Show();
        //    }
        //    NewUser = DataUser.InfoUser(listBoxUser.SelectedValue.ToString());
        //    labelnicknameData.Content = NewUser.nickname;
        //    labelRapidityData.Content = NewUser.rapidity;
        //    labelTrustData.Content = NewUser.trust;
        //    dataGridData.ItemsSource = DataUser.DataRoute(NewUser.idUser);
        //    dataGridData.MaxColumnWidth = 230;
        //}
        //private void ButtonUpdateClick(object sender, RoutedEventArgs e)
        //{
        //    listBoxUser.ItemsSource = DataUser.DataPseudo();
        //}
        //private void UpdateDataGridClick(object sender, RoutedEventArgs e)
        //{

        //    dataGridData.ItemsSource = DataUser.DataRoute(NewUser.idUser);

        //}
        //private void ButtonClearRouteClick(object sender, RoutedEventArgs e)
        //{
        //    NewRoute.Clear();
        //    listBoxCoordonate.ItemsSource = null;
        //    listBoxCoordonate.ItemsSource = NewRoute.LatLong;
        //}
        //private void buttonChangeStatusClick(object sender, RoutedEventArgs e)
        //{
        //    Route RouteChangeStatus = new Route();
        //    RouteChangeStatus = (Route)dataGridData.SelectedValue;
        //    if (RouteChangeStatus != null)
        //    {
        //        DataUser.ModifySatusRoute(NewRoute.IdRoute.ToString());
        //    }
        //    else
        //    {
        //        ErreurAffiche NewErreur = new ErreurAffiche();
        //        NewErreur.labelData.Content = "Select a route before change the status";
        //        NewErreur.Show();
        //    }
        //}

        //private void ListBoxUserMouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    if ((listBoxUser.SelectedValue.ToString() == "Add a player"))
        //    {
        //        NewUser WindowsUser = new WpfApp2.NewUser();
        //        WindowsUser.Show();
        //    }
        //}

        //private void ButtonCreatePDF_Click(object sender, RoutedEventArgs e)
        //{
        //    if ((Route)dataGridData.SelectedValue == null)
        //    {
        //        ErreurAffiche NewErreur = new ErreurAffiche();
        //        NewErreur.labelData.Content = "Select a route before create a pdf";
        //        NewErreur.Show();
        //    }
        //    else
        //    {
        //        RoutePDF NewPdfRoute = new RoutePDF();
        //        NewPdfRoute.Treatment((Route)dataGridData.SelectedValue, NewUser);
        //    }
        //}
        //private void LabelInfoCreatorMouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    InfoCreator NewInfo = new InfoCreator();
        //    NewInfo.Show();
        //}

        private void ButtonLeave_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }

}
