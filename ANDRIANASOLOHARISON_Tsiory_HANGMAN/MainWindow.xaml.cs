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
        private List<string> listMotATrouver = new List<string>
        {
            // Mot à trouver (vous pouvez le changer)
            "Informatique",
            "Reseau",
            "Donnee",
            "base",
            "clavier",
            "souris"
        };

        // Tableau de caractères représentant le mot en cours
        private char[] motCourant; // Mot affiché
        private int viesRestantes; // Nombre de vies restantes
        private string motCache;
        private int imageVie;

        // Constructeur de la fenêtre principale
        public MainWindow()
        {
            InitializeComponent();
            BitmapImage image = new BitmapImage(new Uri("Images/7.png", UriKind.Relative));
            monImage.Source = image;
            BoutonStatut(false);
        }

        // Affiche le mot en cours dans l'interface utilisateur
        private void AfficherMotCourant()
        {
            TB_Reponse.Text = new string(motCourant);
        }

        // Affiche l'image correspondante au nombre de vies restantes
        private void AfficherImage(int imageVie)
        {
            BitmapImage image = new BitmapImage(new Uri("Images/" + imageVie + ".png", UriKind.Relative));
            monImage.Source = image;
        }

        // Met à jour l'affichage du nombre de vies restantes
        private void ActualiserVies()
        {
            TB_vie.Text = viesRestantes.ToString();
        }

        // Gère le clic sur une lettre du clavier
        private void Word_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string letter = btn.Content.ToString();
            CheckLettre(char.Parse(letter));
            btn.IsEnabled = false;
        }

        // Initialise les valeurs lors du démarrage du jeu
        private void InitialiserValeur()
        {
            viesRestantes = 6; // Nombre de vies restantes
            motCache = "";
            imageVie = 1;
            monImage.Source = null;


            // choisir le mot aleatoirement
            Random random = new Random();
            int aleatoire = random.Next(0, listMotATrouver.Count);
            motCache = listMotATrouver[aleatoire];

            ActualiserVies();
        }

        // Active ou désactive les boutons du clavier
        private void BoutonStatut(bool estActif)
        {
            A.IsEnabled = estActif;
            B.IsEnabled = estActif;
            C.IsEnabled = estActif;
            D.IsEnabled = estActif;
            E.IsEnabled = estActif;
            F.IsEnabled = estActif;
            G.IsEnabled = estActif;
            H.IsEnabled = estActif;
            I.IsEnabled = estActif;
            J.IsEnabled = estActif;
            K.IsEnabled = estActif;
            L.IsEnabled = estActif;
            M.IsEnabled = estActif;
            N.IsEnabled = estActif;
            O.IsEnabled = estActif;
            P.IsEnabled = estActif;
            Q.IsEnabled = estActif;
            R.IsEnabled = estActif;
            S.IsEnabled = estActif;
            T.IsEnabled = estActif;
            U.IsEnabled = estActif;
            V.IsEnabled = estActif;
            W.IsEnabled = estActif;
            X.IsEnabled = estActif;
            Y.IsEnabled = estActif;
            Z.IsEnabled = estActif;
            Btn_Terminer.IsEnabled = estActif;
            Btn_Indice.IsEnabled = estActif;
        }

        // Initialise le jeu et démarre une nouvelle partie
        private void Btn_Commencer_Click(object sender, RoutedEventArgs e)
        {
            InitialiserValeur();

            // Activer le clavier
            BoutonStatut(true);


            Button btn = sender as Button;            

            // cacher le mot
            motCourant = new char[motCache.Length * 2 - 1];

            for (int i = 0; i < motCache.Length; i++)
            {
                motCourant[i*2] = '_';

                if (i < motCache.Length - 1)
                {
                    motCourant[i * 2 + 1] = ' ';
                }
            };
            TB_Reponse.Text = new string(motCourant);

            btn.IsEnabled = false;

        }

        // Vérifie si la lettre choisie par le joueur est présente dans le mot à deviner
        private void CheckLettre(char lettre) 
        {
            bool lettretrouvee = false;
            for(int i = 0; i < motCache.Length; i++) 
            {
                if (motCache[i] == char.ToLower(lettre) || motCache[i] == char.ToUpper(lettre))
                {
                    motCourant[i*2] = lettre;
                    lettretrouvee = true;
                }
            }

            if (!lettretrouvee)
            {
                viesRestantes--;
                ActualiserVies();
                AfficherImage(imageVie);
                imageVie++;

            }

            AfficherMotCourant();

            //Manala espace
            if (new string(motCourant).Replace(" ","") == motCache.ToUpper())
            {
                MessageBox.Show("Jeu terminé !");
                Btn_Commencer.IsEnabled = true;
                BoutonStatut(false);
            }

            if (viesRestantes == 0)
            {
                MessageBox.Show("Vous avez perdu. Le mot était : " + motCache);
                Btn_Commencer.IsEnabled = true;
                BoutonStatut(false);
            }
        }

        // Révèle toutes les lettres du mot à deviner
        private void Btn_Terminer_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in motCache.ToUpper())
            {
                CheckLettre(item);
            }
            BoutonStatut(false);
        }

        // Donne un indice en révélant une lettre du mot à deviner
        private void Btn_Indice_Click(object sender, RoutedEventArgs e)
        {
            string motActu = new string(motCourant);
            motActu.Replace(" ", "");
            motActu.Replace("_", "");

            List<char> lettresList = new List<char>();

            foreach (char item in motCache.ToUpper())
            {
                if (!motActu.Contains(item))
                {
                    lettresList.Add(item);
                }
            }

            Random random = new Random();
            int aleatoire = random.Next(0, lettresList.Count);
            char lettre = lettresList[aleatoire];
            CheckLettre(lettre);
            Button boutonCible = FindName(lettre.ToString()) as Button;
            boutonCible.IsEnabled = false;
            Btn_Indice.IsEnabled = false;
        }
    }
}
