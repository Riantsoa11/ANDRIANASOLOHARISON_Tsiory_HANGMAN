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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ANDRIANASOLOHARISON_Tsiory_HANGMAN
{
    public partial class MainWindow : Window
    {
        private string motATrouver = "Informatique,Bonjour,Vie,"; // Mot à trouver (vous pouvez le changer)
        private string motCourant = "-------"; // Mot affiché

        private int viesRestantes = 6; // Nombre de vies restantes

        public MainWindow()
        {
            InitializeComponent();
            AfficherMotCourant();
        }

        private void AfficherMotCourant()
        {
         TB_Reponse.Text = motCourant;
        }

        private void ActualiserVies()
        {
            TB_vie.Text = viesRestantes.ToString();
        }

        private void CheckLettre(char lettre)
        {
            bool lettreTrouvee = false;

            for (int i = 0; i < motATrouver.Length; i++)
            {
                if (motATrouver[i] == lettre)
                {
                    motCourant = motCourant.Substring(0, i) + lettre + motCourant.Substring(i + 1);
                    lettreTrouvee = true;
                }
            }

            if (!lettreTrouvee)
            {
                viesRestantes--;
                ActualiserVies();
            }

            AfficherMotCourant();

            if (motCourant == motATrouver)
            {
                MessageBox.Show("Vous avez gagné !");
                // Mettez ici le code pour recommencer le jeu.
            }

            if (viesRestantes == 0)
            {
                MessageBox.Show("Vous avez perdu. Le mot était : " + motATrouver);
                // Mettez ici le code pour recommencer le jeu.
            }
        }

        // Les événements de clic pour les boutons A à Z


        private void Word_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string letter =  btn.Content.ToString();

        }

        // Répétez ces méthodes pour les autres lettres.

        private void Recommencer_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            
        }
    }
}
