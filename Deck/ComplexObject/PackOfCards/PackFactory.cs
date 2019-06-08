using Deck.Abstract;
using Deck.EnumObject;
using System.Linq;

namespace Deck.ComplexObject
{
    //Фабрика по созданию колод
    public class PackFactory: IFactory
    {
        private IPackTypes typesContainer; //хранилище типов колод карт (52/36 и иные)
        public PackFactory(IPackTypes typesContainer)
        {
            this.typesContainer = typesContainer;
        }

        public PackUnit Create(string packTitle = null, PackTypeVariations packType = PackTypeVariations.cards52)
        {
            var cardValues = typesContainer.GetAvailableCardValues(packType).ToArray(); //диапазон значение 2-туз
            var cardSuits = typesContainer.GetAvailableCardSuits(packType).ToArray(); //диапазон мастей: 4 шт

            var cardArray = new Card[cardValues.Length * cardSuits.Length];
            cardArray = cardSuits //декартово произведение 
                .SelectMany(suit => cardValues.Select(card => new Card() { Name = card, Suit = suit }))
                .ToArray();

            var resultPack = new PackUnit(cardArray, packTitle);

            return resultPack;
        }
    }
}
