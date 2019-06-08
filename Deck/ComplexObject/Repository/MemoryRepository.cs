using System;
using System.Collections.Generic;
using Deck.Abstract;

namespace Deck.ComplexObject
{
    //Хранилище колод в памяти
    internal class MemoryRepository : IDeckRepository
    {
        List<PackUnit> _packUnits = new List<PackUnit>();

        public IEnumerable<PackUnit> Packs
        {
            get => _packUnits;
        }

        public void Add(PackUnit pack)
        {
            _packUnits.Add(pack);
        }

        public bool Remove(PackUnit pack)
        {
            return _packUnits.Remove(pack);
        }
    }
}
