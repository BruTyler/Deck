using Deck.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Deck.ComplexObject
{
    //класс реализует перетасовку руками
    //перекладывание по одной порции за раз 
    public class HandMixer<TCard> : IShuffled<TCard>
        where TCard : class
    {
        Random _rand = new Random();
        int shuffleTimeExternal = 0; //возможность указывать количество перетасовываний для тестирования

        public HandMixer(int shuffleTimeForced = 0)
        {
            shuffleTimeExternal = shuffleTimeForced;
        }

        public IEnumerable<TCard> Shuffle(IEnumerable<TCard> inputPack)
        {
            var _packQueue = new Queue<TCard>();

            foreach (var singleCard in inputPack)
                _packQueue.Enqueue(singleCard);

            int shuffleTimes = shuffleTimeExternal;

            if (shuffleTimes==0) //если снаружи не указано количество перетасовок, то сгенерируем их
                shuffleTimes = _rand.Next(5, 10);

            for (int shuffleRound = 0; shuffleRound < shuffleTimes; shuffleRound++)
            {
                //"за 1 раз берем колоду примерно пополам" ~40-60%
                int cardsInHand = (int)Math.Round(_rand.Next(40, 60) * _packQueue.Count() / 100d);

                for (int stepIntoShuffle = 0; stepIntoShuffle < cardsInHand; stepIntoShuffle++)
                {
                    var currentCard = _packQueue.Dequeue();
                    _packQueue.Enqueue(currentCard);
                }
            }
            return _packQueue;
        }
    }
}
