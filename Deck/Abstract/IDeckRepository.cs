using Deck.ComplexObject;
using System.Collections.Generic;

namespace Deck.Abstract
{
    //Описание хранилища, содержащего созданные колоды карт
    public interface IDeckRepository
    {
        /// <summary>
        /// Все экземпляры колод
        /// </summary>
        IEnumerable<PackUnit> Packs { get; }

        /// <summary>
        /// Добавить колоду
        /// </summary>
        void Add(PackUnit pack);

        /// <summary>
        /// Удалить колоду
        /// </summary>
        bool Remove(PackUnit pack);
    }
}
