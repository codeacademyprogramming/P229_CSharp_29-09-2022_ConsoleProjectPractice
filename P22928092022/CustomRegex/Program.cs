using System;
using System.Text.RegularExpressions;

namespace CustomRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"^[\w\.]+@[a-zA-Z]+\.[a-zA-Z]{2,3}$");

            string email = Console.ReadLine();

            if (regex.IsMatch(email))
            {
                Console.WriteLine("Duzgundu");
            }
            else
            {
                Console.WriteLine("Yanlisdir");
            }
        }
    }
}
