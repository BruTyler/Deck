using Deck;
using Deck.EnumObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new DeckManager();
            Console.WriteLine("  Начало демо-режима");

            Console.WriteLine("  Создание колоды из 36 карт с именем BestPack");
            var pack36 = deck.CreatePack(packTitle: "BestPack", packType: PackTypeVariations.cards36);
            Console.WriteLine("  Содержимое колоды:");
            Console.WriteLine(pack36);
            Console.WriteLine("  Содержимое колоды после перетасовки:");
            deck.ShufflePack(pack36);
            Console.WriteLine(pack36);

            Console.WriteLine("================");
            Console.WriteLine("  Создание 2 колод из 52 карт...");
            var pack52_1 = deck.CreatePack();
            var pack52_2 = deck.CreatePack();
            Console.WriteLine("  Содержимое колоды из 52 карт:");
            Console.WriteLine(pack52_1);

            Console.WriteLine("  Содержимое колоды после перетасовки:");
            deck.ShufflePack(pack52_1);
            Console.WriteLine(pack52_1);

            Console.WriteLine("================");
            Console.WriteLine($"  Всего именованных колод: {deck.GetPackList().Count()}");
            Console.WriteLine($"  Наименования колод:");

            foreach(var singlePack in deck.GetPackList())
                Console.WriteLine($" - {singlePack.Title}");

            Console.WriteLine("================");
            Console.WriteLine("  Получение колоды по имени BestPack");
            var pack36_restored = deck.GetPackByTitle("BestPack");
            Console.WriteLine("  Содержимое колоды:");
            Console.WriteLine(pack36_restored);

            Console.WriteLine("================");
            Console.WriteLine($"  Удаление колоды по имени BestPack удалось={deck.RemovePack("BestPack")}");
            Console.WriteLine($"  Всего осталось именованных колод: {deck.GetPackList().Count()}");
            Console.WriteLine($"  Наименования оставшихся колод:");
            foreach (var singlePack in deck.GetPackList())
                Console.WriteLine($" - {singlePack.Title}");

            Console.WriteLine("================");
            Console.WriteLine("  Конец демо-режима");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
