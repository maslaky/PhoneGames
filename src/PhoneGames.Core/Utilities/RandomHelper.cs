using System;
using System.Text;

namespace PhoneGames.Utilities
{
    public class RandomHelper
    {
        public static string RandomFourLetterString()  
        {  
            StringBuilder builder = new StringBuilder();  
            Random random = new Random();  
            char ch;  
            for (int i = 0; i < 4; i++)  
            {  
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));  
                builder.Append(ch);  
            }   
            return builder.ToString();  
        } 
    }
}