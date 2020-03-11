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

namespace HangmanCS
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
        /*
        private void RefreshNumberOfFailures()
        {
            List<string> images = new List<string>();
                {
                images.Add(":/backgrounds/graphics/Hangman01.png");
                images.Add(":/backgrounds/graphics/Hangman02.png");
                images.Add(":/backgrounds/graphics/Hangman03.png");
                images.Add(":/backgrounds/graphics/Hangman04.png");
                images.Add(":/backgrounds/graphics/Hangman05.png");
                images.Add(":/backgrounds/graphics/Hangman06.png");
                images.Add(":/backgrounds/graphics/Hangman07.png");
                images.Add(":/backgrounds/graphics/Hangman08.png");
                images.Add(":/backgrounds/graphics/Hangman09.png");
                images.Add(":/backgrounds/graphics/Hangman10.png");
                images.Add(":/backgrounds/graphics/Hangman11.png");
                images.Add(":/backgrounds/graphics/Hangman12.png");
                };

        }
        */
        private void Button_Click(object sender, RoutedEventArgs e)
        {/*
            List<string> images = new List<string>();
            {
                images.Add(":/resources/images/Hangman01.png");
                images.Add(":/resources/images/Hangman02.png");
                images.Add(":/resources/images/Hangman03.png");
                images.Add(":/resources/images/Hangman04.png");
                images.Add(":/resources/images/Hangman05.png");
                images.Add(":/resources/images/Hangman06.png");
                images.Add(":/resources/images/Hangman07.png");
                images.Add(":/resources/images/Hangman08.png");
                images.Add(":/resources/images/Hangman09.png");
                images.Add(":/resources/images/Hangman10.png");
                images.Add(":/resources/images/Hangman11.png");
                images.Add(":/resources/images/Hangman12.png");
            };*/
            BitmapImage bmp = new BitmapImage(new Uri("resources/images/Hangman01.png"));
            Image img = new Image();
            img.Source = bmp;
        }


    }
}
