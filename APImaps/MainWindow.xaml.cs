﻿using System;
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
using APImaps.PDF;

namespace APImaps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IPlayer dal=new DALPlayer();
        IRoute dalro = new DALRoute();
        IRapidity dalr = new DALRapidity();
        ITrust dalt = new DALTrust();
        IStatus dals = new DALStatus();
        GetDataApi api = new GetDataApi();
        public MainWindow()
        {
            InitializeComponent();
            listBoxUserPeople.ItemsSource = dal.GetPlayers();
            listBoxUserRoute.ItemsSource = dal.GetPlayers();
            listBoxUserPdf.ItemsSource = dal.GetPlayers();
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

        private void ListBoxRoutesPeople_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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

        private void ButtonUpdateInRoute_Click(object sender, RoutedEventArgs e)
        {
            listBoxUserRoute.ItemsSource = dal.GetPlayers();
        }

        private void AddCoordonate_Click(object sender, RoutedEventArgs e)
        {
            api.AddWaypoints(CoordonateBox.Text);
            CoordonateBox.Clear();
            ListBoxCoordonate.ItemsSource = null;
            ListBoxCoordonate.ItemsSource = api.Waypoints;
        }

        private void AddRoute_Click(object sender, RoutedEventArgs e)
        {
            if(listBoxUserRoute.SelectedItem==null)
            {
                ErrorLabel.Content = "Sélectionner un player pour pouvoir lui ajouter une route";
            }
            else if(api.Waypoints.Count<1)
            {
                ErrorLabel.Content = "Ajouter au moins une coordonnées avant de vouloir ajouter une route";
            }
            else
            {
                dalro.AddRoute(dalro.Calculate(api, (Player)listBoxUserRoute.SelectedItem));
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            api.Waypoints = null;
            ListBoxCoordonate.ItemsSource = api.Waypoints;
        }

        private void CreatePdf_Click(object sender, RoutedEventArgs e)
        {
            Player p = (Player)listBoxUserPdf.SelectedItem;
            Route r = (Route)ListBoxRoutesPdf.SelectedItem;
            PdfCreator newPdf = new PdfCreator();
            newPdf.Treatment(r, p);
        }

        private void DeleteRouteButton_Click(object sender, RoutedEventArgs e)
        {
            if(ListBoxRoutesPeople.SelectedItem!=null)
            {
                dalro.DeleteRoute((Route)ListBoxRoutesPeople.SelectedItem);
            }
        }
    }

}
