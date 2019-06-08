using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deck.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Deck.EnumObject;
using Deck.ComplexObject;

namespace UnitTestCardMixer
{
    [TestClass]
    public class CardsTest
    {
        [TestMethod]
        public void Can_Create_Pack_MockTypeStorage()
        {
            var cardValues = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            var cardSuits = new string[] { "Serdce", "Romb", "Piki", "Vini" };

            Mock<IPackTypes> FakeTypeStorage = new Mock<IPackTypes>();
            FakeTypeStorage.Setup(m => m.GetAvailableCardSuits(PackTypeVariations.cards52)).Returns(cardSuits);
            FakeTypeStorage.Setup(m => m.GetAvailableCardValues(PackTypeVariations.cards52)).Returns(cardValues);

            var factory = new PackFactory(FakeTypeStorage.Object);

            var newPackCard = factory.Create(packTitle: "realPack", packType: PackTypeVariations.cards52);

            Assert.AreEqual("realPack", newPackCard.Title);
            Assert.AreEqual(52, newPackCard.Cards.Count);
            Assert.AreEqual("2", newPackCard.Cards[0].Name);
            Assert.AreEqual("Serdce", newPackCard.Cards[0].Suit);
            Assert.AreEqual("A", newPackCard.Cards[51].Name);
            Assert.AreEqual("Vini", newPackCard.Cards[51].Suit);
        }
    }
}
