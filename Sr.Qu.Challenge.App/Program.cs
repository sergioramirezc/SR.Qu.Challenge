using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sr.Qu.Challenge.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var finder = new WordFinder(new List<string>() { "abcdc", "fgwio", "chill", "pqnsd", "uvdxy" });
                var words = finder.Find(new List<string>() { "chill", "cold", "wind", "snow" });
                foreach (var word in words)
                {
                    Console.WriteLine(word);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
