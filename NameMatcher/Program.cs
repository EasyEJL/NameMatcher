using System;
using System.Linq;

namespace NameMatcher
{
    public class Program
    {
        static void Main(string[] args)
        {
            var firstFile = "users.csv";
            var secondFile = "newusers.csv";

            if (args.Count() == 2)
            {
                firstFile = args[0];
                secondFile = args[1];
            }

            foreach (var user in FileProcessor.GetSecondaryEmailForMatchingName(firstFile, secondFile))
            {
                Console.WriteLine(user.Email);
            }                
        }
    }
}
