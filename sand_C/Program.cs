// See https://aka.ms/new-console-template for more information

//C.Электронная таблица(10 баллов)

/*ограничение по времени на тест
1 секунда
ограничение по памяти на тест
256 мегабайт
ввод
стандартный ввод
вывод
стандартный вывод

Вам необходимо написать часть функциональности обработки сортировок в электронных таблицах.

Задана прямоугольная таблица n×m (n строк по m столбцов) из целых чисел.

Если кликнуть по заголовку i-го столбца, то строки таблицы пересортируются таким образом, что в этом столбце значения будут идти по неубыванию 
(то есть возрастанию или равенству). При этом, если у двух строк одинаковое значение в этом столбце, то относительный порядок строк не изменится.
*/

using System.Text;

int setsCount;
int.TryParse(Console.ReadLine(), out setsCount);
StringBuilder output = new StringBuilder();

for (short i = 0; i < setsCount; i++)
{
    Console.ReadLine();
    int n, m;
    
    //string input = Console.ReadLine();
    string[] splitted = Console.ReadLine().Split(" ");
    int.TryParse(splitted[0], out n);
    int.TryParse(splitted[1], out m);
    int[][] table = new int[n][];
    for (short row = 0; row < n; row++)
    {
        table[row] = new int[m];
        //input = Console.ReadLine();
        splitted = Console.ReadLine().Split(" ");
        for (short col = 0; col < m; col++)
        {
            int.TryParse(splitted[col], out table[row][col]);
        }
    }
    int.TryParse(Console.ReadLine(), out int clickCount);
    //input = Console.ReadLine();
    splitted = Console.ReadLine().Split(" ");
    var clicks = new int[clickCount];
    for (short j = 0; j < clickCount; j++)
    {
        int.TryParse(splitted[j], out clicks[j]);
        int sortCol = (clicks[j] - 1);
        var reserveRow = new int[n];
        bool changed;
        do
        {
            changed = false;
            for (short row = 0; row < n-1; row++)
            {
                if (table[row][sortCol] > table[row + 1][sortCol])
                {
                    changed = true;
                    reserveRow = table[row];
                    table[row] = table[row + 1];
                    table[row + 1] = reserveRow;
                }
            }
        } while (changed);
    }
    output.AppendLine();
    foreach (var row in table)
    {
        foreach (var num in row)
            output.Append(num + " ");
        output.AppendLine();
    }
}

//Console.WriteLine("\n Summary:");
Console.WriteLine(output.ToString());
//Console.ReadLine();
