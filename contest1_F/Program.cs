using System.Text;

int setsCount;
int.TryParse(Console.ReadLine(), out setsCount);
StringBuilder output = new StringBuilder();

for (int i = 0; i < setsCount; i++)
{
    //Console.ReadLine();
    //string input = Console.ReadLine();

    Dictionary<string, string> book = new Dictionary<string, string>();
    bool isCorrect = true;
    string[] splitted = Console.ReadLine().Split(" ");
    int.TryParse(splitted[0], out int n);
    int j = 0;
    int[] right = new int[3];
    int[] left = new int[3];
    int start = 0;
    int end = 0;

    while (isCorrect && j < n)
    {
        string input = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrEmpty(input))
        {
            continue;
        }
        splitted = input.Split("-");
        right[0] = int.Parse(splitted[0].Split(":")[0]);
        right[1] = int.Parse(splitted[0].Split(":")[1]);
        right[2] = int.Parse(splitted[0].Split(":")[2]);
        left[0] = int.Parse(splitted[1].Split(":")[0]);
        left[1] = int.Parse(splitted[1].Split(":")[1]);
        left[2] = int.Parse(splitted[1].Split(":")[2]);

        if ((right[0] < 0) || (right[0] > 23))
        {
            isCorrect = false;
            break;
        }
        if ((right[1] < 0) || (right[1] > 59))
        {
            isCorrect = false;
            break;
        }
        if ((right[2] < 0) || (right[2] > 59))
        {
            isCorrect = false;
            break;
        }
        if ((left[0] < 0) || (left[0] > 23))
        {
            isCorrect = false;
            break;
        }
        if ((left[1] < 0) || (left[1] > 59))
        {
            isCorrect = false;
            break;
        }
        if ((left[2] < 0) || (left[2] > 59))
        {
            isCorrect = false;
            break;
        }

        start = (right[0] * 360) + (right[1] * 60) + (right[2]);
        end = (left[0] * 360) + (left[1] * 60) + (left[2]);

        if (start > end)
        {
            isCorrect = false;
            break;
        }


        j++;
    }
    if (isCorrect)
        output.AppendLine("YES");
    else 
        output.AppendLine("NO");
}

Console.WriteLine(output.ToString());
