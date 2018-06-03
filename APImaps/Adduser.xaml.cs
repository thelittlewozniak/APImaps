using APImaps.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace APImaps
{
    /// <summary>
    /// Interaction logic for Adduser.xaml
    /// </summary>
    public partial class Adduser : Window
    {
        public Adduser()
        {
            InitializeComponent();
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {
            bool test=true;
            if (txtBoxNickname.Text == "")
            {
                ErrorBox.Text = "Entry for username invalid";
                test = false;
            }
            if ((Convert.ToInt32(txtBoxRapidity.Text) < 1 || Convert.ToInt32(txtBoxRapidity.Text) > 3) || txtBoxRapidity.Text == "")
            {
                ErrorBox.Text = "Entry for rapidity invalid";
                test = false;
            }
            if ((Convert.ToInt32(txtBoxTrust.Text) < 1 || Convert.ToInt32(txtBoxTrust.Text) > 3) || txtBoxTrust.Text == "")
            {
                ErrorBox.Text = "entry for Trust invalid";
            }
            if (test == true)
            {
                DALPlayer dal = new DALPlayer();
                DALRapidity dalr = new DALRapidity();
                DALTrust dalt = new DALTrust();

                Player newPlayer = new Player();
                newPlayer.nickname = txtBoxNickname.Text;
                newPlayer.rapidity = dalr.GetRapidity(Convert.ToInt32(txtBoxRapidity.Text));
                newPlayer.trust = dalt.GetTrust(Convert.ToInt32(txtBoxTrust.Text));
                dal.AddPlayer(newPlayer);
                Close();

            }

        }
    }
}
