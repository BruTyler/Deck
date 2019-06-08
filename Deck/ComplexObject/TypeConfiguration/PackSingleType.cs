using Deck.Abstract;
using Deck.EnumObject;
using System;

namespace Deck.ComplexObject
{
    //Класс описывает настройки одной колоды: минимальная величина карты, максимальная величина карты и какие масти участвуют при создании колоды
    //Источник данных enum перечисления
    public class PackSingleType: IPackSingleType
    {
        private CardValue _minCard;
        private CardValue _maxCard;
        private CardSuit _maxSuit;

        public int MinCardValue { get => (int)_minCard; set => _minCard = (CardValue)value; }
        public int MaxCardValue { get => (int)_maxCard; set => _maxCard = (CardValue)value; }

        public int MaxCardSuit { get => (int)_maxSuit; set => _maxSuit = (CardSuit)value; }


        public string GetCardNameById(int idCardValue)
        {
            return Enum.GetName(typeof(CardValue), idCardValue);
        }

        public string GetCardSuitById(int idCardSuit)
        {
            return Enum.GetName(typeof(CardSuit), idCardSuit);
        }
    }
}
