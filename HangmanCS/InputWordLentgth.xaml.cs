using System;
using System.Windows;
using System.Windows.Input;
using WPFSetup.Util;

namespace HangmanCS
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class InputWordLength : Window
    {
        public int InputLength { get; set; }

        public InputWordLength(int value)
        {
            InitializeComponent();
            GetWordLength.Text = value.ToString();
        }

        private void Button_OKClick(object sender, RoutedEventArgs e)
        {
            InputLength = int.Parse(GetWordLength.Text);
            if (InputLength > 18 || InputLength <= 3)
            {
                MessageBoxHelper.PrepToCenterMessageBoxOnForm(this); //Centers the messagebox on the application
                MessageBox.Show("gib eine Zahl zwischen 1 & 15 ein!", "Hangman", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Close();
            }
        }

        private void GetWordLength_KeyDown(object sender, KeyEventArgs e)
        {
            KeyConverter converter = new KeyConverter();
            string inputStr;
            char input;

            switch (e.Key)
            {
                case Key.NumPad0:
                    input = '0';
                    break;
                case Key.NumPad1:
                    input = '1';
                    break;
                case Key.NumPad2:
                    input = '2';
                    break;
                case Key.NumPad3:
                    input = '3';
                    break;
                case Key.NumPad4:
                    input = '4';
                    break;
                case Key.NumPad5:
                    input = '5';
                    break;
                case Key.NumPad6:
                    input = '6';
                    break;
                case Key.NumPad7:
                    input = '7';
                    break;
                case Key.NumPad8:
                    input = '8';
                    break;
                case Key.NumPad9:
                    input = '9';
                    break;
                default:
                    inputStr = converter.ConvertToString(e.Key);//Convert to string
                    input = inputStr[0];                         //first letter in string to char
                    break;
            }

            if (!Char.IsDigit(input))
            {
                MessageBoxHelper.PrepToCenterMessageBoxOnForm(this); //Centers the messagebox on the application
                MessageBox.Show("Es sind nur Zahlen erlaubt!", "Hangman", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
