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

namespace DAMIER2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // matrice de TextBlocks
        Button[,] btnCases = new Button[10, 10];
        public MainWindow()
        {
            InitializeComponent();
            PrepareQuadrillage();
        }
        public void PrepareQuadrillage()
        {

            // dimension de la fenêtre
            this.Width = 660;
            this.Height = 660;
            //particularités (taille texte...)
            this.FontSize = 36;
            this.Title = "DAMIER 2";

            // subdivision de la grille
            // dimension des colonnes
            ColumnDefinition[] colDef = new ColumnDefinition[btnCases.GetLength(0)];
            for (int i = 0; i < btnCases.GetLength(0); i++)
            {
                colDef[i] = new ColumnDefinition();
            }
            // ajout des colonnes à la grille
            for (int i = 0; i < btnCases.GetLength(0); i++)
            {
                grdMain.ColumnDefinitions.Add(colDef[i]);
            }
            // dimension des lignes
            RowDefinition[] rowDef = new RowDefinition[btnCases.GetLength(0)];
            for (int i = 0; i < btnCases.GetLength(0); i++)
            {
                rowDef[i] = new RowDefinition();
            }
            // ajout des lignes à la grille
            for (int i = 0; i < btnCases.GetLength(0); i++)
            {
                grdMain.RowDefinitions.Add(rowDef[i]);
            }
            // construction et attribution d'une Textblock à chaque cellule de la grille + gestionnaire d'événement MouseDown
            for (int i = 0; i < btnCases.GetLength(0); i++)
            {
                for (int j = 0; j < btnCases.GetLength(0); j++)
                {
                    btnCases[i, j] = new Button();
                    btnCases[i, j].Width = 65;
                    btnCases[i, j].Height = 65;
                    btnCases[i, j].Foreground = Brushes.Red;
                    btnCases[i, j].FontWeight = FontWeights.Bold;
                    btnCases[i, j].Content = CalculNumeroV2(i, j);
                    Grid.SetRow(btnCases[i, j], i);
                    Grid.SetColumn(btnCases[i, j], j);
                    grdMain.Children.Add(btnCases[i, j]);
                    btnCases[i, j].HorizontalAlignment = HorizontalAlignment.Center;
                    btnCases[i, j].VerticalAlignment = VerticalAlignment.Center;
                    //btnCases[i, j].Click += new RoutedEventHandler(Case_Click);
                    if ((int)btnCases[i,j].Content % 2 == 0 )
                    {
                        btnCases[i, j].Background = Brushes.White;
                    }
                    else
                    {
                        btnCases[i, j].Background = Brushes.Black;
                    }
                }
            }
        }

        public int CalculNumeroV2(int i, int j)
        {
            int numero;
            if (i % 2 == 0)
            {
                numero = j + 1 + (10 * i);
            }
            else
            {
                numero = (10 * i) + 10 - j;
            }
            return numero;
        }
    }
}
