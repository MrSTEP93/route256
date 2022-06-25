using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//B.Сумма к оплате (10 баллов)
/*ограничение по времени на тест
1 секунда
ограничение по памяти на тест
256 мегабайт


В магазине акция: «купи три одинаковых товара и заплати только за два». Конечно, каждый купленный товар может участвовать лишь в одной акции. Акцию можно использовать многократно.

Например, если будут куплены 7
товаров одного вида по цене 2 за штуку и 5 товаров другого вида по цене 3 за штуку, то вместо 7⋅2+5⋅3 надо будет оплатить 5⋅2+4⋅3=22

Считая, что одинаковые цены имеют только одинаковые товары, найдите сумму к оплате.

Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.
*/

namespace sand_B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint numSets, sum;
            string input, output = "";
            string[] pairs;

            Dictionary<string, uint> goods = new Dictionary<string, uint>();
            uint.TryParse(Console.ReadLine(), out numSets);
            for (int i = 0; i < numSets; i++)
            {
                sum = 0;
                goods.Clear();
                Console.ReadLine();
                input = Console.ReadLine();
                pairs = input.Split(' ');
                foreach (string item in pairs)
                {
                    uint price = uint.Parse(item);
                    if (!goods.TryGetValue(item, out uint _a)) 
                        goods.Add(item, 0);
                    goods[item]++;
                    if (goods[item] == 3)
                    {
                        sum -= price;
                        goods[item] = 0;
                    }
                    sum += price;
                }
                output += sum.ToString() + "\n";
            }
            Console.WriteLine(output);
            //Console.ReadLine();
        }
    }
}
