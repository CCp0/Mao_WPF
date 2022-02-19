using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mao
{
    public class Deck
    {
        //All made card variables 
        private static List<string> hand = new List<string>(); //List of cards out of deck
        public Deck()
        {

        }
        public string CardName { get; set; } //Card name (e.g Ace, two, three)
        public string CardSuit { get; set; } //Card suit (e.g hearts, spades)
        public int CardValue { get; set; }  //Card score or value
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
