using Deck.ComplexObject;
using Deck.EnumObject;

namespace Deck.Abstract
{
    public interface IFactory
    {
        /// <summary>
        /// Создание экземпляра колоды
        /// </summary>
        PackUnit Create(string packTitle, PackTypeVariations packType);
    }
}
