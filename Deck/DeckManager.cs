using Deck.Abstract;
using Deck.ComplexObject;
using Deck.EnumObject;
using Ninject;
using System.Collections.Generic;
using System.Linq;

namespace Deck
{
    public class DeckManager
    {
        private IKernel DIKernel = new StandardKernel(new DIConfig());

        private readonly IPackTypes _packTypes; //контейнер типов колод (52, 36 или могут быть иные типы)
        private readonly IFactory _packFactory; //фабрика для создание новых экземпляров колод
        private readonly IDeckRepository _packStorage; //хранилище созданных экземпляров колод
        private readonly IShuffled<Card> _choosenMixer; //выбранный тип растасовки

        public DeckManager()
        {
            _packTypes = DIKernel.Get<IPackTypes>();
            _packFactory = DIKernel.Get<IFactory>();
            _packStorage = DIKernel.Get<IDeckRepository>();
            _choosenMixer = DIKernel.Get<IShuffled<Card>>();
        }

        public IEnumerable<PackUnit> GetPackList()
        {
            return _packStorage.Packs;
        }

        public PackUnit GetPackByTitle(string packTitle)
        {
            PackUnit packUnit = _packStorage.Packs
                .Where(singlePack => singlePack.Title == packTitle)
                .FirstOrDefault();

            return packUnit;
        }

        public PackUnit CreatePack(string packTitle = null, PackTypeVariations packType = PackTypeVariations.cards52)
        {
            PackUnit packUnit = _packFactory.Create(packTitle, packType);
            _packStorage.Add(packUnit);

            return packUnit;
        }

        public void ShufflePack(PackUnit pack)
        {
            pack.Shuffle(_choosenMixer.Shuffle);
        }

        public bool RemovePack(string packTitle)
        {
            var packUnit = GetPackByTitle(packTitle);
            return _packStorage.Remove(packUnit);
        }
    }
}
