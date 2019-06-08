using Deck.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Deck.ComplexObject
{
    //простая перетасовка - 1 карта перекладывается в рандомное место
    public class SimpleMixer<TCard> : IShuffled<TCard>
        where TCard : class
    {
        Random _rand = new Random();
        int shuffleTimeExternal = 0; //возможность указывать количество перетасовываний для тестирования

        public SimpleMixer(int shuffleTimeExternal = 0)
        {
            this.shuffleTimeExternal = shuffleTimeExternal;
        }

        public IEnumerable<TCard> Shuffle(IEnumerable<TCard> inputPack)
        {
            if (inputPack == null || inputPack.Count() < 2)
                throw new ArgumentException("не является колодой карт");

            var _pack = inputPack.ToList();
            int packMaxIndex = inputPack.Count();

            int shuffleTimes = shuffleTimeExternal;

            if (shuffleTimes == 0) //если снаружи не указано количество перетасовок, то сгенерируем их
                shuffleTimes = _rand.Next(50, 100);

            for (int shuffleRound = 0; shuffleRound < shuffleTimes; shuffleRound++)
            {
                //взяли произвольную карту
                var oldCardPosition = _rand.Next(0, packMaxIndex);
                var transferringCard = _pack[oldCardPosition];
                _pack.RemoveAt(oldCardPosition);

                //вставили карту в произвольное место
                var newCardPosition = _rand.Next(0, packMaxIndex);
                _pack.Insert(newCardPosition, transferringCard);
            }
            return _pack;
        }
    }
}
