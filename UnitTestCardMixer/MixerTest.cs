using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deck.ComplexObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCardMixer
{
    [TestClass]
    public class MixerTest
    {
        [TestMethod]
        public void HandMixer_1_Round_Of_Shuffle()
        {
            var simpleMixer = new HandMixer<string>(1);
            var originalArray = new List<string>() { "a", "b", "c", "d", "e" };
            var shuffledArray = simpleMixer.Shuffle(originalArray).ToList();

            Assert.AreEqual(originalArray.Count(), shuffledArray.Count());
            Assert.AreEqual(0, originalArray.Except(shuffledArray).Count());
            Assert.AreEqual(originalArray.Distinct().Count(), shuffledArray.Distinct().Count());
            Assert.AreEqual(5, originalArray.Intersect(shuffledArray).Count());

            Assert.IsTrue(shuffledArray[0] != "a");
            Assert.IsTrue(shuffledArray[1] != "b");
            Assert.IsTrue(shuffledArray[2] != "c");
            Assert.IsTrue(shuffledArray[3] != "d");
            Assert.IsTrue(shuffledArray[4] != "e");

            Assert.IsTrue(shuffledArray[0] == "e" || shuffledArray[0] == "d" || shuffledArray[0] == "c");
        }

        [TestMethod]
        public void SimpleMixer_1_Round_Of_Shuffle()
        {
            var simpleMixer = new SimpleMixer<string>(1);
            var originalArray = new List<string>() { "a", "b", "c", "d", "e" };
            var shuffledArray = simpleMixer.Shuffle(originalArray).ToList();
   
            Assert.AreEqual(originalArray.Count(), shuffledArray.Count());
            Assert.AreEqual(0, originalArray.Except(shuffledArray).Count());
            Assert.AreEqual(originalArray.Distinct().Count(), shuffledArray.Distinct().Count());
            Assert.AreEqual(5, originalArray.Intersect(shuffledArray).Count());
        }

        [TestMethod]
        public void SimpleMixer_Can_Iterate_More_52_items()
        {
            var simpleMixer = new SimpleMixer<string>(1);
            var baseArray = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

            var list100Items = baseArray.SelectMany(x => baseArray.Select(y => string.Concat(x+"."+y))).ToList();
            var shuffledArray = simpleMixer.Shuffle(list100Items).ToList();

            Assert.AreEqual(100, list100Items.Count());
            Assert.AreEqual(list100Items.Count(), shuffledArray.Count());
        }


    }
}
