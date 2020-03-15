using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        //set Project Path
        readonly string projectPath = Path.GetFullPath(@"..\..\..\");

        int numberOfFailures = 0;

        string wordToGuess;


        readonly List<string> images = new List<string>();
        List<string> wordList;
        readonly List<char> keyStroke = new List<char>();


        public MainWindow()
        {
            InitializeComponent();
            ImageList(); //Fill imgaes in a List
            GetWord(); //Gets the word from word.txt
            CheckGameOverAndUpdateGUI(); //Update the GUI with the Background Image
            UpdateWordInGUI();
        }

        private void ImageList()
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

        private void GetWord()
        {
            //opens the Textfile and puts the lines into a string array
            string[] lines = File.ReadAllLines(projectPath + "\\resources\\words\\words.txt");
            //string array into a list
            wordList = new List<string>(lines);

            //select word with generatet number and convert to uppercase
            while (string.IsNullOrEmpty(wordToGuess) || wordToGuess.Length > 14)
            {
                wordToGuess = wordList[RandomNumber(wordList.Count)].ToUpper();
                Debug.WriteLine(wordToGuess, "word to Guess");
                Debug.WriteLine(wordToGuess.Length, "word to Guess wortlaenge");
            }
        }

        private int RandomNumber(int max)
        {
            Random random = new Random();
            var randomNumber = random.Next(1, max);
            return randomNumber;
        }

        private void UpdateWordInGUI()
        {
            var counter2 = 0;//DEBUG
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
                counter2++;
                Debug.WriteLine(counter2, "for _");
            }

            LabelWordToGuess.Content = textForLabel;

            if(!textForLabel.Contains("_"))
            {
                MessageBoxHelper.PrepToCenterMessageBoxOnForm(this); //Centers the messagebox on the application
                MessageBoxResult yesNo = MessageBox.Show("Du hast Gewonnen! Neues Wort Laden?", "Hangman", MessageBoxButton.YesNo, MessageBoxImage.Information);
               
                switch (yesNo)
                {
                    case MessageBoxResult.Yes:
                        Reset();
                        break;

                    case MessageBoxResult.No:
                        Environment.Exit(1);
                        break;
                }
            }
        }
        


        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            //Resets the Playground and loads a new Word
            numberOfFailures = 0;
            keyStroke.Clear();
            wordToGuess = "";
            LabelWordToGuess.Content = $"";
            CheckGameOverAndUpdateGUI();
            GetWord();
            UpdateWordInGUI();
        }

        private void CheckGameOverAndUpdateGUI()
        {

            //Sets the Background Image
            if (images.Count > numberOfFailures)
            {
                Uri fileUri = new Uri(projectPath + images[numberOfFailures]);
                Background.Source = new BitmapImage(fileUri);
                LableGameOver.Visibility = Visibility.Hidden;
            }
            else
            {
                LableGameOver.Visibility = Visibility.Visible;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBoxHelper.PrepToCenterMessageBoxOnForm(this); //Centers the messagebox on the application

            //checks if key is a letter, convert it and add id to key Stroke List
            if (e.Key >= Key.A && e.Key <= Key.Z)
            {
                KeyConverter converter = new KeyConverter();
                string letterStr = converter.ConvertToString(e.Key);
                char letter = letterStr[0];
                Debug.WriteLine(letter, "pressed key is a letter");

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
                        Debug.WriteLine(letter, "pressed key is a letter");
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
    }
}
