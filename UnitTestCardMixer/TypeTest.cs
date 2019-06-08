using System;
using Deck.ComplexObject;
using Deck.EnumObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;
using Deck.Abstract;
using Ninject;

namespace UnitTestCardMixer
{
    [TestClass]
    public class TypeTest
    {
        [TestMethod]
        public void Can_Create_Pack_Of_52_PreDefinedType()
        {
            //PackSingleType - тип заранее определенный PreDefinedType

            var typeContainer = new PackTypes<PackSingleType> ();

            typeContainer.RemoveAllPackType();//очищаем 
            
            typeContainer.AddPackType(
                definitionOfPack: PackTypeVariations.cards52,
                minValue: (int)CardValue.Two,
                maxValue: (int)CardValue.Ace,
                maxSuit: 4
            );
            var availableTypes = typeContainer.GetAllPackTypes().ToList();

            var cardSuitCount = typeContainer.GetAvailableCardSuits(availableTypes[0]).Count();
            var cardNameCount = typeContainer.GetAvailableCardValues(availableTypes[0]).Count();

            var totalCardInPack = cardSuitCount * cardNameCount;

            Assert.AreEqual(1, availableTypes.Count);
            Assert.AreEqual(4, cardSuitCount);
            Assert.AreEqual(13, cardNameCount);
            Assert.AreEqual(52, totalCardInPack);
        }
   

        [TestMethod]
        public void Can_Create_Pack_Custom_6Cards()
        {
            //PackSingleType - тип заранее определенный PreDefinedType

            var typeContainer = new PackTypes<PackSingleType>();

            typeContainer.RemoveAllPackType();//очищаем 

            typeContainer.AddPackType(
                definitionOfPack: PackTypeVariations.custom,
                minValue: (int)CardValue.Nine,
                maxValue: (int)CardValue.Ten,
                maxSuit: 3
            );
            var availableTypes = typeContainer.GetAllPackTypes().ToList();

            var cardSuitCount = typeContainer.GetAvailableCardSuits(availableTypes[0]).Count();
            var cardNameCount = typeContainer.GetAvailableCardValues(availableTypes[0]).Count();

            var totalCardInPack = cardSuitCount * cardNameCount;

            Assert.AreEqual(1, availableTypes.Count);
            Assert.AreEqual(3, cardSuitCount);
            Assert.AreEqual(2, cardNameCount);
            Assert.AreEqual(6, totalCardInPack);
        }
    }
}
