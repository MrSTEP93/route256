using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sand_A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input, output = "";
            string[] pairs;
            int.TryParse(Console.ReadLine(), out int num);
            for (int i = 0; i < num; i++)
            {
                input = Console.ReadLine();
                pairs = input.Split(' ');
                output += (Convert.ToInt32(pairs[0]) + Convert.ToInt32(pairs[1])).ToString() + "\n";
            }
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
