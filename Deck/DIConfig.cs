using Deck.Abstract;
using Deck.ComplexObject;
using Deck.EnumObject;
using Ninject.Modules;
using System;
using System.Configuration;
using System.Net.Configuration;

namespace Deck
{
    internal class DIConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IPackTypes>().To<PackTypes<PackSingleType>>(); //контейнер типов колод (52, 36 или могут быть иные типы)
            Bind<IFactory>().To<PackFactory>();  //фабрика колод
            Bind<IDeckRepository>().To<MemoryRepository>(); //хранилище созданных экземпляров колод


            var globalConfig = (AppSettings)ConfigurationManager.GetSection("Settings");
            
            //выбранный тип растасовки
            switch ((MixerType)globalConfig.MixerType) 
            {
                case MixerType.Hand:
                    Bind<IShuffled<Card>>().To<HandMixer<Card>>(); 
                    break;
                case MixerType.Simple:
                    Bind<IShuffled<Card>>().To<SimpleMixer<Card>>();
                    break;
                default:
                    throw new ApplicationException("Некорректный тип растасовки в конфигурационном файле");
            }

        }
    }
}
