using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deck.Abstract
{
    //настройки одной колоды 
    public interface IPackSingleType
    {
        /// <summary>
        /// Минимальное значение карты в колоде (2 для двойки)
        /// </summary>
        int MinCardValue { get; set; }

        /// <summary>
        /// Максимальное значение карты в колоде (где туз=14)
        /// </summary>
        int MaxCardValue { get; set; }

        /// <summary>
        /// Получить человекочитаемое значение карты
        /// </summary>
        /// <param name="idCardValue">индекс карты[2-14]</param>
        /// <returns>значение карты[two-ace]</returns>
        string GetCardNameById(int idCardValue);


        /// <summary>
        /// Максимальное кол-во мастей в колоде [1-4]
        /// </summary>
        int MaxCardSuit { get; set; }

        /// <summary>
        /// Получить человекочитаемое значение масти
        /// </summary>
        /// <param name="idCardSuit">индекс масти[1-4]</param>
        /// <returns>значение масти[heart и т.д.]</returns>
        string GetCardSuitById(int idCardSuit);
    }
}
