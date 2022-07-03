// See https://aka.ms/new-console-template for more information

using System.Text;

StringBuilder output = new();

string[] splitted = Console.ReadLine().Split(" ");
int.TryParse(splitted[0], out int n);
int.TryParse(splitted[1], out int q);
int[] users = new int[n];
List<int> globals = new();
int notifyNumber = 0;
int lastGlobal = 0;

for (int i = 0; i < q; i++)
{
    splitted = Console.ReadLine().Split(" ");
    int.TryParse(splitted[0], out int t);
    int.TryParse(splitted[1], out int id);

    // на тесте 2 уже сыпемся!!!

    switch (t)
    {
        case 1:
            notifyNumber++;
            if (id == 0)
            {
                globals.Clear();
                globals.AddRange(users);
                lastGlobal = notifyNumber;
            } else
            {
                users[id-1] = notifyNumber;
                globals.Remove(id - 1);
            }
            break;
        case 2:
            if (globals.Contains(id)) 
                output.AppendLine(lastGlobal.ToString());
            else 
                output.AppendLine(users[id-1].ToString());
            break;
        default:
            break;
    }
}

//Console.WriteLine("\nSummary");
Console.WriteLine(output.ToString());