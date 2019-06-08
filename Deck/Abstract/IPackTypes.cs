using Deck.EnumObject;
using System.Collections.Generic;

namespace Deck.Abstract
{
    //Описание менеджера, который работает с типами колод
    public interface IPackTypes
    {
        /// <summary>
        /// Запросить все типы колод
        /// </summary>
        IEnumerable<PackTypeVariations> GetAllPackTypes();

        /// <summary>
        /// Создать определенный тип колоды
        /// </summary>
        /// <param name="definitionOfPack">индекс предопределенных типов колод [0-2]</param>
        /// <param name="minValue">минимальный индекс карты в колоде (например 2 - для двойки)</param>
        /// <param name="maxValue">минимальный индекс карты в колоде (например 14 - для туза)</param>
        /// <param name="maxSuit">максимальное количество мастей[1-4]</param>
        void AddPackType(PackTypeVariations definitionOfPack, int minValue, int maxValue, int maxSuit);

        /// <summary>
        /// Удалить определенный тип колоды
        /// </summary>
        bool RemovePackType(PackTypeVariations definitionOfPack);

        /// <summary>
        /// Получить перечень всех возможных Значений карт в колоде
        /// </summary>
        IEnumerable<string> GetAvailableCardValues(PackTypeVariations definitionOfPack);

        /// <summary>
        /// Получить перечень всех возможных Мастей колоды
        /// </summary>
        IEnumerable<string> GetAvailableCardSuits(PackTypeVariations definitionOfPack);

        /// <summary>
        /// Удалить все типы колод
        /// </summary>
        void RemoveAllPackType();
    }
}
