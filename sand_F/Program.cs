/*
ограничение по времени на тест
10 секунд
ограничение по памяти на тест
256 мегабайт
ввод
стандартный ввод
вывод
стандартный вывод
*/
/*
F.Система продажи билетов на поезда (20 баллов)

    Есть вагон, в котором n купе, каждое купе содержит 2 места (купе типа СВ). Места пронумерованы от 1 до 2n подряд 
(места 1-2 — это первое купе, места 3-4 — второе и так далее). Надо обрабатывать три вида запросов:

    купить билет на заданное место (надо ответить SUCCESS или FAIL в зависимости свободно оно сейчас или нет) и пометить это место занятым;
    вернуть билет на заданное место (ответить SUCCESS или FAIL в зависимости удачно завершилась операция или нет) и разметить место, то есть SUCCESS надо выводить, если место было на данный момент занято;
    выкупить целиком купе (ответить либо FAIL, либо вывести SUCCESS X-Y — границу мест в первом полностью свободном купе), пометить все места этого купе занятыми.

    Обработайте все запросы.
*/

using System.Text;

int.TryParse(Console.ReadLine(), out int setsCount);
StringBuilder output = new();

for (int i = 0; i < setsCount; i++)
{
    Console.ReadLine();
    string[] splitted = Console.ReadLine().Split(" ");
    int.TryParse(splitted[0], out int n);
    int.TryParse(splitted[1], out int q);
    int placesCount = n * 2;
    bool[] vagon = new bool[placesCount];
    SortedSet<int> coupes = new();
    for (int l = 0; l < n; l++)
        coupes.Add(l);

    for (int j = 0; j < q; j++)
    {
        string result = "";
        string input = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrEmpty(input))
        {
            continue;
        }
        splitted = input.Split(" ");
        int.TryParse(splitted[0], out int act);
        int p = 0;
        if (splitted.Length > 1)
        {
            int.TryParse(splitted[1], out p);
            p--;    
        }
        switch (act)
        {
        case 1:
                if (vagon[p])
                {
                    result = "FAIL";
                } else
                {
                    result = "SUCCESS";
                    vagon[p] = true;
                    if (coupes.Contains(p / 2))
                        coupes.Remove(p / 2);
                }
            break;
        case 2:
                if (vagon[p])
                {
                    result = "SUCCESS";
                    vagon[p] = false;
                    p = (p % 2 == 0) ? p : (p - 1);
                    if (!vagon[p] && !vagon[p+1])
                    {
                        if (!coupes.Contains(p / 2))
                        {
                            coupes.Add(p / 2);
                        }
                    }
                }
                else
                {
                    result = "FAIL";
                }
                break;
        case 3:
                int k;
                if (coupes.Count > 0)
                {
                    k = coupes.FirstOrDefault();
                    coupes.Remove(k);
                    k *= 2;
                    vagon[k] = vagon[k + 1] = true;
                    result = "SUCCESS " + (k + 1) + "-" + (k + 2);
                } else
                {
                    result = "FAIL";
                }
                    
            break;
        default:
            break;
        }
        output.AppendLine(result);  
    }

    output.AppendLine();
}

//Console.WriteLine("\n Summary:");
Console.WriteLine(output.ToString());
