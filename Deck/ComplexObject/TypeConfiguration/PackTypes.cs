using Deck.EnumObject;
using System;
using System.Collections.Generic;
using System.Linq;
using Deck.Abstract;

namespace Deck.ComplexObject
{
    //Класс описывает все сконфигурированные Типы колод: 52, 36 или custom
    
    public class PackTypes<TSingle>: IPackTypes
        where TSingle:IPackSingleType, new()
    {
        private Dictionary<PackTypeVariations, TSingle> _packVariations;

        public PackTypes()
        {
            _packVariations = new Dictionary<PackTypeVariations, TSingle>();

            //по умолчанию создается 2 типа колод: на 52 и 36 карт
            AddPackType(PackTypeVariations.cards52, (int)CardValue.Two, (int)CardValue.Ace);
            AddPackType(PackTypeVariations.cards36, (int)CardValue.Six, (int)CardValue.Ace);
        }

        public void AddPackType(PackTypeVariations definitionOfPack, int minValue, int maxValue, int maxSuit = 4)
        {
            _packVariations.Add(definitionOfPack, new TSingle() { MinCardValue = minValue, MaxCardValue = maxValue, MaxCardSuit = maxSuit });
        }

        public IEnumerable<PackTypeVariations> GetAllPackTypes()
        {
            return _packVariations.Keys;
        }

        public IEnumerable<string> GetAvailableCardSuits(PackTypeVariations definitionOfPack)
        {
            if (_packVariations.TryGetValue(definitionOfPack, out var singlePack))
            {
                return Enumerable
                    .Range(1, singlePack.MaxCardSuit)
                    .Select(cardIndex => singlePack.GetCardSuitById(cardIndex));
            }
            else
            {
                throw new ArgumentException("тип колоды не определен");
            }
        }

        public IEnumerable<string> GetAvailableCardValues(PackTypeVariations definitionOfPack)
        {
            if (_packVariations.TryGetValue(definitionOfPack, out var concreteSinglePack))
            {
                int lastIndexofRangeInterval = concreteSinglePack.MaxCardValue + 1 - concreteSinglePack.MinCardValue;
                return Enumerable
                    .Range(concreteSinglePack.MinCardValue, lastIndexofRangeInterval)
                    .Select(cardIndex => concreteSinglePack.GetCardNameById(cardIndex));
            }
            else
            {
                throw new ArgumentException("тип колоды не определен");
            }
        }

        public bool RemovePackType(PackTypeVariations definitionOfPack)
        {
            if (_packVariations.TryGetValue(definitionOfPack, out _))
                return _packVariations.Remove(definitionOfPack);
            else
                throw new ArgumentException("тип колоды не определен");
        }

        public void RemoveAllPackType()
        {
            _packVariations.Clear();
        }
    }
}
