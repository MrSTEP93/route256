// See https://aka.ms/new-console-template for more information

using System.Text;

int.TryParse(Console.ReadLine(), out int setsCount);
StringBuilder output = new();
for (int i = 0; i < setsCount; i++)
{
    //Dictionary<string, bool> isPackageInstalled = new();
    Dictionary<string, Package> packages = new();
    int istallationsCount = 0;
    Console.ReadLine();
    
    void Install(string module)
    {
        if (!packages[module].IsInstalled)
        { 
            if (packages[module].DependsCount == 0)
            {
                packages[module].IsInstalled = true;
                istallationsCount++;
                output.Append(module + " ");
            }
            else
            {
                foreach (var depend in packages[module].Depends)
                {
                    Install(depend);
                }
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
        if (input == "database:")
        {
            // alarrm;
        }
        splitted = input.Split(":");
        packages.Add(splitted[0], new Package(string.IsNullOrEmpty(splitted[1]) ? null : splitted[1]));
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
        istallationsCount = 0;
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
    private int _dependsCount;

    public bool IsInstalled { get => _isInstalled; set => _isInstalled = value; }
    public string[] Depends { get => _depends; private set => _depends = value; }
    public int DependsCount { get => _dependsCount; private set => _dependsCount = value; }

    public void MarkAsInstall()
    {
        IsInstalled = true;
    }

    public Package(string deps)
    {
        _isInstalled = false;
        if (deps == null)
        {
            _depends = null;
            _dependsCount = 0;
        } else
        {
            _depends = deps.Trim().Split(" ");
            _dependsCount = _depends.Length;
        }
    }
}