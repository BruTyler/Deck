using System.Collections.Generic;

namespace Deck.Abstract
{
    //перетасовка
    public interface IShuffled<TCard>
    {
        /// <summary>
        /// перетасовка любого количества объектов и возврат новой структуры
        /// </summary>
        IEnumerable<TCard> Shuffle(IEnumerable<TCard> inputPack);
    }
}
