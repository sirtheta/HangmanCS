using System;
using System.Windows;
using System.IO;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Diagnostics;

namespace HangmanCS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly string projectPath = Path.GetFullPath(@"..\..\..\");
        int counter = 0;
        readonly List<string> images = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            ImagesToList();
            SetImage();
        }
        
        private void ImagesToList()
        {
            
            images.Add("\\resources\\images\\Hangman01.png");
            images.Add("\\resources\\images\\Hangman02.png");
            images.Add("\\resources\\images\\Hangman03.png");
            images.Add("\\resources\\images\\Hangman04.png");
            images.Add("\\resources\\images\\Hangman05.png");
            images.Add("\\resources\\images\\Hangman06.png");
            images.Add("\\resources\\images\\Hangman07.png");
            images.Add("\\resources\\images\\Hangman08.png");
            images.Add("\\resources\\images\\Hangman09.png");
            images.Add("\\resources\\images\\Hangman10.png");
            images.Add("\\resources\\images\\Hangman11.png");
            images.Add("\\resources\\images\\Hangman12.png");
        }  

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            counter += 1;
            SetImage();         
            
        }

        private void SetImage()
        {
            Debug.WriteLine(counter, "counter");

            if (images.Count > counter)
            {
                Uri fileUri = new Uri(projectPath + images[counter]);
                Background.Source = new BitmapImage(fileUri);
            }
            else
            {
                Debug.WriteLine("out of range");
                LableGameOver.Visibility = Visibility.Visible;
            }
        }

    }
}
