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

namespace DAMIER3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // matrice de TextBlocks
        Button[,] btnCases = new Button[8, 8];
        public MainWindow()
        {
            InitializeComponent();
            PrepareQuadrillage();
        }
        public void PrepareQuadrillage()
        {

            // dimension de la fenêtre
            this.Width = 540;
            this.Height = 540;
            //particularités (taille texte...)
            this.FontSize = 36;
            this.Title = "DAMIER 3";

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
                    btnCases[i, j].Width = 67;
                    btnCases[i, j].Height = 67;

                    if ((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0))
                    {
                        btnCases[i, j].Background = Brushes.Black;
                    }
                    else
                    {
                        btnCases[i, j].Background = Brushes.White;
                    }
                    if (i == 0 || i == 7|| i == 1 || i == 6)
                    {
                        BitmapImage imageBouton = new BitmapImage();
                        imageBouton.BeginInit();
                        if ( i == 0 || i == 7)
                        {
                            if (j == 0 || j == 7)
                            {
                                imageBouton.UriSource = new Uri("assets/t.png", UriKind.Relative);
                            }
                            else if (j == 1 || j == 6)
                            {
                                imageBouton.UriSource = new Uri("assets/kn.png", UriKind.Relative);
                            }
                            else if (j == 2 || j == 5)
                            {
                                imageBouton.UriSource = new Uri("assets/b.png", UriKind.Relative);
                            }
                            else if (j == 3 )
                            {
                                imageBouton.UriSource = new Uri("assets/k.png", UriKind.Relative);
                            }
                            else
                            {
                                imageBouton.UriSource = new Uri("assets/q.png", UriKind.Relative);
                            }
                        }
                        else if (i == 1 || i == 6)
                        {
                            imageBouton.UriSource = new Uri("assets/p.png", UriKind.Relative);
                        }
                    
                        imageBouton.EndInit();

                        Image imBouton = new Image();
                        imBouton.Source = imageBouton;
                        imBouton.Stretch = System.Windows.Media.Stretch.None;
                        btnCases[i, j].Content = imBouton;
                    }
                    Grid.SetRow(btnCases[i, j], i);
                    Grid.SetColumn(btnCases[i, j], j);
                    grdMain.Children.Add(btnCases[i, j]);
                    btnCases[i, j].HorizontalAlignment = HorizontalAlignment.Center;
                    btnCases[i, j].VerticalAlignment = VerticalAlignment.Center;
                    //btnCases[i, j].Click += new RoutedEventHandler(Case_Click);
                    
                }
            }
        }
    }
}
