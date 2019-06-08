using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deck.ComplexObject
{
    //Инфа по 1 колоде: сами карты и заголовок (именованная колода)
    public class PackUnit
    {
        private List<Card> _pack;
        public string Title { get; private set; }
        public List<Card> Cards => _pack;

        public PackUnit(IEnumerable<Card> cards, string title = null)
        {
            _pack = cards.ToList();
            Title = title ?? Guid.NewGuid().ToString();
        }

        public void Shuffle(Func<IEnumerable<Card>, IEnumerable<Card>> shuffleDelegate)
        {
            _pack = shuffleDelegate(_pack).ToList();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var cardFullName in _pack)
                sb.Append(cardFullName);

            return sb.ToString();
        }
    }
}
