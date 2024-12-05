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

namespace I_WPF_CalcBin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // gestion des événements
            txtNombre1.PreviewTextInput += new TextCompositionEventHandler(txtNombreBinaire_KeyPress);
            txtNombre2.PreviewTextInput += new TextCompositionEventHandler(txtNombreBinaire_KeyPress);
            btnCalculer.Click += new RoutedEventHandler(btnCalculer_Click);
            btnReset.Click += new RoutedEventHandler(btnReset_Click);
        }
        /// <summary>
        /// vérification de la frappe :  on n'accepte que l'encodage des 0 et des 1 ou le backSpace
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreBinaire_KeyPress(object sender, TextCompositionEventArgs e)
        {
            if (!(e.Text == "1" || e.Text == "0" || (int)char.Parse(e.Text) == 8))
            {
                e.Handled = true;
            }          
        }
        /// <summary>
        /// calcul de l'opération demandée si les données encodées répondent aux critères précisés
        /// Avertissement si dépassement de capacité
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalculer_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre2.Text != "" && txtNombre1.Text != "" && txtNombre1.Text.Length < 8 && txtNombre1.Text.Length < 8)
            {
                ushort[] TBN1;
                ushort[] TBN2;
                MethodesDuProjet MesOutils = new MethodesDuProjet();
                // remplir les tableaux en mettant le plus grand nombre dans TN1
                if (Convert.ToInt32(txtNombre2.Text.ToString()) < Convert.ToInt32(txtNombre1.Text.ToString()))
                {
                    TBN1 = new ushort[txtNombre1.Text.Length];
                    TBN1 = MesOutils.RemplirTableau(txtNombre1.Text);
                    TBN2 = new ushort[txtNombre2.Text.Length];
                    TBN2 = MesOutils.RemplirTableau(txtNombre2.Text);
                }
                else
                {
                    TBN1 = new ushort[txtNombre2.Text.Length];
                    TBN1 = MesOutils.RemplirTableau(txtNombre2.Text);
                    TBN2 = new ushort[txtNombre1.Text.Length];
                    TBN2 = MesOutils.RemplirTableau(txtNombre1.Text);
                }
                // choix de l'opération
                if (optAddition.IsChecked==true)
                {
                    ushort[] tRes;
                    bool ok;
                    MesOutils.Additionne(TBN1, TBN2, out tRes, out ok);
                    if (ok)
                    {
                        txtResultat.Text = MesOutils.Concatene(tRes);
                    }
                    else
                    {
                        txtResultat.Text = "Dépassement de capacité !";
                    }
                }
                else if (optSoustraction.IsChecked == true)
                {
                    ushort[] tRes;
                    if (MesOutils.Soustrait(TBN1, TBN2, out tRes))
                    {
                        txtResultat.Text = MesOutils.Concatene(tRes);
                    }
                    else
                    {
                        txtResultat.Text = "Dépassement de capacité !";
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez encoder deux nombres binaires d'au plus 7 bits.");
            }
        }
        /// <summary>
        /// Nettoyage de l'interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtNombre1.Text = "";
            txtNombre2.Text = "";
            txtResultat.Text = "";
        }
    }
}
