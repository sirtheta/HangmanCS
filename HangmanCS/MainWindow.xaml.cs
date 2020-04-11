using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WPFSetup.Util; //Calling messagebox centeringClass

namespace HangmanCS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        int numberOfFailures = 0;
        int wordLength;
        string wordToGuess;


        readonly List<string> images = new List<string>();
        readonly List<string> wordList = new List<string>();
        readonly List<char> keyStroke = new List<char>();


        public MainWindow()
        {
            InitializeComponent();
            ImageList(); //Fill images in a List
            PrepareNewGame();
        }

        private void ImageList()
        {

            images.Add("pack://application:,,,/resources/images/Hangman01.png");
            images.Add("pack://application:,,,/resources/images/Hangman02.png");
            images.Add("pack://application:,,,/resources/images/Hangman03.png");
            images.Add("pack://application:,,,/resources/images/Hangman04.png");
            images.Add("pack://application:,,,/resources/images/Hangman05.png");
            images.Add("pack://application:,,,/resources/images/Hangman06.png");
            images.Add("pack://application:,,,/resources/images/Hangman07.png");
            images.Add("pack://application:,,,/resources/images/Hangman08.png");
            images.Add("pack://application:,,,/resources/images/Hangman09.png");
            images.Add("pack://application:,,,/resources/images/Hangman10.png");
            images.Add("pack://application:,,,/resources/images/Hangman11.png");
            images.Add("pack://application:,,,/resources/images/Hangman12.png");
        }

        //TODO: Move GetWord() to Logic
        private void GetWord()
        {
            Logic random = new Logic();

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "HangmanCS.resources.words.txt";

            Stream stream = assembly.GetManifestResourceStream(resourceName);
            StreamReader reader = new StreamReader(stream);
            
            while (reader.Peek() >= 0)
            {
                wordList.Add(reader.ReadLine());
            }


            //select word with generatet number and convert to uppercase
            while (string.IsNullOrEmpty(wordToGuess) || wordToGuess.Length != wordLength)
            {
                wordToGuess = wordList[random.RandomNumber(3, wordList.Count)].ToUpper();
            }
        }

        private void UpdateWordInGUI()
        {
            string textForLabel = "";

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (i != 0)
                {
                    textForLabel += " ";
                }

                if (keyStroke.Contains(wordToGuess[i]))
                {
                    textForLabel += wordToGuess[i];
                }

                else
                {
                    textForLabel += "__"; //two underscores because first will be recognised as Access key and not displayed
                }
            }

            LabelWordToGuess.Content = textForLabel;

            if (!textForLabel.Contains("_"))
            {
                MessageBoxHelper.PrepToCenterMessageBoxOnForm(this); //Centers the messagebox on the application
                MessageBoxResult yesNo = MessageBox.Show("Du hast Gewonnen! Neues Wort Laden?", "Hangman", MessageBoxButton.YesNo, MessageBoxImage.Information);

                switch (yesNo)
                {
                    case MessageBoxResult.Yes:
                        PrepareNewGame();
                        break;

                    case MessageBoxResult.No:
                        Environment.Exit(1);
                        break;
                }
            }
        }

        private void DlgGetLetterNumber()
        {
            int defaultWordLength = 5;
            var dlgInput = new InputWordLength(defaultWordLength);
            dlgInput.ShowDialog();
            wordLength = dlgInput.InputLength;

            if (wordLength == 0)
            {
                int min = 3;
                int max = 17;

                Logic random = new Logic();

                wordLength = random.RandomNumber(min, max);
            }

        }

        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            PrepareNewGame();
        }

        private void PrepareNewGame()
        {
            //Resets the Playground and loads a new Word
            numberOfFailures = 0;
            keyStroke.Clear();
            wordToGuess = "";
            LabelWordToGuess.Content = $"";
            CheckGameOverAndUpdateGUI();//Update the GUI with the Background Image
            DlgGetLetterNumber();
            GetWord(); //Gets the word from word.txt
            UpdateWordInGUI();
        }

        private void CheckGameOverAndUpdateGUI()
        {
            //Sets the Background Image
            if (images.Count > numberOfFailures)
            {
                Uri fileUri = new Uri(images[numberOfFailures]);
                Background.Source = new BitmapImage(fileUri);
                LableGameOver.Visibility = Visibility.Hidden;
            }
            if (numberOfFailures >= 11)
            {
                LableGameOver.Visibility = Visibility.Visible;
                LabelWordToGuess.Content = wordToGuess;

            }
        }

        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBoxHelper.PrepToCenterMessageBoxOnForm(this); //Centers the messagebox on the application

            //checks if key is a letter, convert it and add id to key Stroke List
            if (e.Key >= Key.A && e.Key <= Key.Z)
            {
                char letter = new KeyConverter().ConvertToString(e.Key)[0]; //first letter in string to char

                if (keyStroke.Contains(letter))
                {
                    MessageBox.Show("Buchstabe schon eingegeben!", "Hangman", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                else
                {
                    keyStroke.Add(letter); //eingegeben buchstabe zur Liste hinzufügen

                    if (wordToGuess.Contains(letter))
                    {
                        //keyStroke.Add(letter);
                        UpdateWordInGUI();
                    }
                    else
                    {
                        numberOfFailures++;
                        CheckGameOverAndUpdateGUI();
                    }
                }
            }
            else
            {
                MessageBox.Show("Es sind nur Buchstaben von A-Z erlaubt!", "Hangman", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Hint_Button_Click(object sender, RoutedEventArgs e)
        {
            Logic random = new Logic();

            var rndHint = random.RandomNumber(1, wordToGuess.Length);
            keyStroke.Add(wordToGuess[rndHint]);
            UpdateWordInGUI();
            numberOfFailures++;
            CheckGameOverAndUpdateGUI();
        }
    }
}
