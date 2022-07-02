// See https://aka.ms/new-console-template for more information

using System.Text;

int.TryParse(Console.ReadLine(), out int setsCount);
StringBuilder output = new();
for (int i = 0; i < setsCount; i++)
{
    //Dictionary<string, bool> isPackageInstalled = new();
    Dictionary<string, Package> packages = new();
    Console.ReadLine();
    
    void Install(string module)
    {

        if (!packages[module].IsInstalled)
        {
            int i = 0;
            if (packages[module].Depends.Length == 0)
            {
                packages[module].MarkAsInstall();
                output.Append(module + " ");
            }
            else
            {
                Install(packages[module].Depends[i]);
                i++;
            }
        }
    }

    string[] splitted = Console.ReadLine().Split(" ");
    int.TryParse(splitted[0], out int n);                   // n :: кол-во модулей в проекте
    //string[] modules = new string[n];
    for (int j = 0; j < n; j++)
    {
        //string result = "";
        string input = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrEmpty(input))
        {
            continue;
        }
        splitted = input.Split(":");
        packages.Add(splitted[0], new Package(splitted[1] ?? null));
        //packages[splitted[0]] = new()
        //{
        //    Depends = splitted[1] ?? string.Empty,
        //    isInstalled = false
        //};
    }

    splitted = Console.ReadLine().Split(" ");
    int.TryParse(splitted[0], out int q);                   // q :: количество запросов на компиляцию
    for (int k = 0; k < q; k++)
    {
        string reqest = Console.ReadLine();
        Install(reqest);
    }
    output.AppendLine();
}

Console.WriteLine("\n Summary:");
Console.WriteLine(output.ToString());


struct Package
{
    private bool _isInstalled;
    private string[] _depends;

    public bool IsInstalled { get => _isInstalled; private set => _isInstalled = value; }
    public string[] Depends { get => _depends; private set => _depends = value; }

    public void MarkAsInstall()
    {
        this.IsInstalled = true;
    }

    public Package(string deps)
    {
        if (deps == "database")
        {
            // alarrm;
        }
        _isInstalled = false;
        if (deps == null)
        {
            _depends = null;
        } else
        {
            _depends = deps.Trim().Split(" ");
        }
        
    }
}