using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRank
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] scores = new int[] { 400, 651, 829, 651, 400, 405, 400 };
            var res = scores.Join(
            scores
            //упорядочиваем
            .OrderBy(score => score)
            //запоминаем упорядоченные позиции
            .Select((score, position) => new { Score = score, Position = position + 1 })
            //группируем
            .GroupBy(x => x.Score)
            //выбираем ключ и среднее значение позиции
            .Select(g => new { Score = g.Key, Rang = g.Average(element => element.Position) }),
            o => o,
            i => i.Score,
            (o, i) => new { Score = o, i.Rang }
            );
            //вывод
            foreach (var result in res)
            {
                Console.WriteLine("{0} - {1}", result.Score, result.Rang);
            }
            Console.Read();
        }
    }
}
