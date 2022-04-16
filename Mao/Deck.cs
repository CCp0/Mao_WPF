using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
namespace Mao
{
    public class Deck
    {
        private int currentCard;  //used to keep track for current card for getting next card in deck
        string errFilePath = "../ErrorLog.txt";
        public List<Card> Cards { get; set; }

        public Deck()
        {
            try
            {
                Cards = new List<Card>();
                string[] suits = { "Hearts", "Spades", "Diamonds", "Clubs" };
                string[] faces = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

                for (int i = 0; i < suits.Length; i++)
                {
                    for (int j = 0; j < faces.Length; j++)
                    {
                        Card c = new Card();
                        c.CardSuit = suits[i];
                        c.CardFace = faces[j];
                        c.CardName = faces[j] + " of " + suits[i];
                        c.CardValue = j + 1;
                        Cards.Add(c);
                    }
                }
            }
            catch (Exception err)
            {
                DateTime date = DateTime.Now;
                string text = "\n" + date + " " + err.Message;
                File.AppendAllText(errFilePath, text);
            }
        }
        public void RefreshDeck(List<Card> cardsReturned)
        {
            try
            {
                Cards.Clear();
                currentCard = 0;
                for (int i = 0; i < cardsReturned.Count - 1; i++) //Returns all cards except the top one
                {
                    Cards.Add(cardsReturned[i]);
                }
                Shuffle();
            }
            catch (Exception err)
            {
                string text = "\n" + DateTime.Now + " " + err.Message;
                File.AppendAllText(errFilePath, text);
            }
        }
        public void Shuffle()
        {
            try
            {
                Random r = new Random();

                for (int i = 0; i < Cards.Count; i++)
                {
                    //Card temp = Cards[randomNumber];
                    //Cards[randomNumber] = Cards[i];
                    //Cards[i] = temp;
                    Cards = Cards.OrderBy(item => r.Next(0, Cards.Count)).ToList();
                }
            }
            catch (Exception err)
            {
                string text = "\n" + DateTime.Now + " " + err.Message;
                File.AppendAllText(errFilePath, text);
            }
        }
        public Card GetNextCard()
        {
            return Cards[currentCard++];
        }
        public void DisplayCards()
        {
            try
            {
                foreach (Card c in Cards)
                {
                    Console.WriteLine("{0} of {1}", c.CardName, c.CardSuit);
                }
            }
            catch (Exception err)
            {
                string text = "\n" + DateTime.Now + " " + err.Message;
                File.AppendAllText(errFilePath, text);
            }
        }
    }
}
