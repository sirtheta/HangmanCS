using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace HangmanCS
{
    public class Logic
    {
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            var randomNumber = random.Next(min, max);
            return randomNumber;
        }

        public void GetWord(ref List<string> wordList, ref string wordToGuess, ref int wordLength)
        {

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
                wordToGuess = wordList[RandomNumber(3, wordList.Count)].ToUpper();
            }
        }

        public void ImageList(ref List<string> images)
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

    }
}
