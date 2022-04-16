using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Mao
{
    public class Deck
    {
            private int currentCard;  //used to keep track for current card for getting next card in deck

            public List<Card> Cards { get; set; }

            public Deck()
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
            public void RefreshDeck(List<Card> cardsReturned)
            {
            Cards.Clear();
            currentCard = 0;
                for(int i = 0; i < cardsReturned.Count - 1; i++) //Returns all cards except the top one
                {
                    Cards.Add(cardsReturned[i]);
                }
            Shuffle();
            }
            public void Shuffle()
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
            public Card GetNextCard()
            {
                return Cards[currentCard++];
            }
            public void DisplayCards()
            {
                foreach (Card c in Cards)
                {
                    Console.WriteLine("{0} of {1}", c.CardName, c.CardSuit);
                }
            }
        }
        public class Deck2
        {
        //All made card variables 
        public static List<string> hand = new List<string>(); //List of cards out of deck
        public Deck2()
        {

        }
        public string CardName { get; set; } //Card name (e.g Ace, two, three)
        public string CardSuit { get; set; } //Card suit (e.g hearts, spades)
        public int CardValue { get; set; }   //Card score or value
        public void DrawCard()
        {
            //Declaration of variables
            Random random = new Random(); //Random number generator
            string[] cardNames = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
            string[] cardSuit = { "Hearts", "Clubs", "Spades", "Diamonds" };
            int[] _cValuesArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };//Declaration of score values
            int nameIndex = random.Next(cardNames.Length), suitIndex = random.Next(cardSuit.Length);//Declaration of random card index
            string newCard = cardNames[nameIndex] + " of " + cardSuit[suitIndex];//Predefined for the first card dealt
            for (int i = 0; i < hand.Count; i++)
            {
                do
                {   //Changes the name and suit index so it draws a different card each time
                    nameIndex = random.Next(cardNames.Length);
                    suitIndex = random.Next(cardSuit.Length);
                    //Card name (e.g 9, king, jack etc) of random suit (e.g hearts, clubs etc)  
                    newCard = cardNames[nameIndex] + " of " + cardSuit[suitIndex];
                }
                while (hand.Contains(newCard)); //If the new card is on the table make a new card
            }
            hand.Add(newCard);                      //Adds the new card to the hand
            CardName = newCard;                     //Card names and card suits are combined to make the full CardName
            CardValue = _cValuesArray[nameIndex];   //The index for both name array and value array correspond to each other
            CardSuit = cardSuit[suitIndex];
        }
        public void TotalReset(List<Card> cards)
        {
            hand.Clear();   //Resets the cards taken out of deck
            cards.Clear();  //Clears the cards from the table
        }
    }
}
