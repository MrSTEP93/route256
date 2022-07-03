// See https://aka.ms/new-console-template for more information


using System.Text;

int.TryParse(Console.ReadLine(), out int setsCount);
StringBuilder output = new();

for (byte i = 0; i < setsCount; i++)
{
    //Console.ReadLine();
    string[] splitted = Console.ReadLine().Split(" ");
    short.TryParse(splitted[0], out short n);
    Dictionary<short, int> monkey = new();
    int teamsCount = n / 2;

    string input = Console.ReadLine() ?? string.Empty;
    splitted = input.Split(" ");
    short m = 1;
    foreach (var str in splitted)
    {
        monkey.Add(m,int.Parse(str));
        m++;
    }

    //for (int j = 0; j < n; j++)
    //{
    //    string input = Console.ReadLine() ?? string.Empty;
    //    if (string.IsNullOrEmpty(input))
    //    {
    //        continue;
    //    }
    //    //output.AppendLine();
    //}

    for (int k = 0; k < teamsCount; k++)
    {
        int level = monkey.FirstOrDefault().Value;
        short tm1 = monkey.FirstOrDefault().Key;
        short tm2 = 0;
        int best = 200;
        monkey.Remove(tm1);
        foreach (var user in monkey)
        {
            int _diff = Math.Abs(level - user.Value);
            if (_diff < best)
            {
                best = _diff;
                tm2 = user.Key;
            }
        }
        monkey.Remove(tm2);
        output.AppendLine(tm1 + " " + tm2);
    }

    output.AppendLine();
}

//Console.WriteLine("\n Summary:");
Console.WriteLine(output.ToString());
