using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mao;
using LeaderboardDataAdd;
using System;

namespace MaoTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckStandardUnshuffledDeck()
        {
            //Arrange
            Deck d1 = new Deck();
            Deck d2 = new Deck();

            //Act
            Card c1 = d1.GetNextCard();
            Card c2 = d2.GetNextCard();

            //Assert
            Assert.IsTrue(c1.ToString() == c2.ToString());
        }
        [TestMethod]
        public void TestDeckShuffle()
        {
            //Arrange
            Deck d1 = new Deck();
            Deck d2 = new Deck();

            //Act
            d2.Shuffle();
            Card c1 = d1.GetNextCard();
            Card c2 = d2.GetNextCard();
            //Assert
            Assert.IsFalse(c1.ToString() == c2.ToString());
        }
    }
}
