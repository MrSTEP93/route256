// See https://aka.ms/new-console-template for more information
// D. Подсистема регистрации (15 баллов)

/*ограничение по времени на тест
5 секунд
ограничение по памяти на тест
256 мегабайт
ввод
стандартный ввод
вывод
стандартный вывод

Реализуйте часть подсистемы валидации для функциональности регистрации.

Задана последовательность строк — это логины, которые указывали пользователи при регистрации. Для каждого логина вывести YES или NO 
в зависимости от того валидный это логин или нет.

Надо проверять, что логин — это последовательность из латинских букв в любом регистре, цифр и символов '_' или '-' (подчеркивание и дефис).
Логин не должен начинаться с дефиса. Логин должен иметь длину от 2 до 24 символов. Логины, которые отличаются только регистром, считаются одинаковыми.

Если логин задан многократно, то только первое его вхождение проходит валидацию (зарегистрироваться повторно с таким же логином нельзя). 
Например, если сперва происходит регистрация с логином tester, а затем с логином TesteR, то вторая попытка будет неуспешной (надо вывести NO для неё).
*/

using System.Text;
using System.Text.RegularExpressions;

int setsCount;
int.TryParse(Console.ReadLine(), out setsCount);
StringBuilder output = new StringBuilder();
string login = "";
//string pattern = ("[0-9a-zA-Z_][0-9a-zA-Z_-]{1,23}");
Regex rule = new("^[0-9a-zA-Z_][0-9a-zA-Z_-]{1,23}$");

for (short i = 0; i < setsCount; i++)
{
    //Console.ReadLine();
    //string input = Console.ReadLine();

    List<string> busy = new List<string>();

    string[] splitted = Console.ReadLine().Split(" ");
    int.TryParse(splitted[0], out int n);

    for (short j = 0; j < n; j++)
    {
        login = Console.ReadLine();
        //if (Regex.IsMatch(login, pattern, RegexOptions.IgnoreCase))
        if (rule.IsMatch(login))
        {
            if (busy.Contains(login.ToLower()))
            {
                output.AppendLine("NO");
            } else
            {
                output.AppendLine("YES");
                busy.Add(login.ToLower());
            }
        } else
        {
            output.AppendLine("NO");
        }
    }
    output.AppendLine();
}

//Console.WriteLine("\n Summary:");
Console.WriteLine(output.ToString());
//Console.ReadLine();