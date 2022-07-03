using System.Text;

int.TryParse(Console.ReadLine(), out int setsCount);
StringBuilder output = new();

for (int i = 0; i < setsCount; i++)
{
    string[] splitted = Console.ReadLine().Split(" ");
    int.TryParse(splitted[0], out int n);
    Dictionary<int, bool> tasksFinished = new();
    int task = 0;
    int _prev = 0;
    splitted = Console.ReadLine().Split(" ");
    bool nice = true;
    int j = 0;
    while (nice && (j < n))
    {
        task = int.Parse(splitted[j]);
        if (_prev != task)
        {
            if (_prev != 0)
                tasksFinished[_prev] = true;
            _prev = task;
            if (tasksFinished.ContainsKey(task))
            {
                if (tasksFinished[task] == true)
                {
                    nice = false;
                }
            }
            else
            {
                tasksFinished.Add(task, false);
            }
        }
        j++;
    }
    if (nice)
    {
        output.AppendLine("YES");
    } else
    {
        output.AppendLine("NO");
    }
}

//Console.WriteLine("\n Summary:");
Console.WriteLine(output.ToString());