using Deck.Abstract;
using System;
using System.Collections.Generic;

namespace Deck.ComplexObject
{
    //заглушка для переноса хранилища колод в БД
    internal class DBRepository : IDeckRepository
    {
        public IEnumerable<PackUnit> Packs => throw new NotImplementedException();

        public void Add(PackUnit pack)
        {
            throw new NotImplementedException();
        }

        public bool Remove(PackUnit pack)
        {
            throw new NotImplementedException();
        }
    }
}
