using System;
using System.Collections.Generic;
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
    }
}
