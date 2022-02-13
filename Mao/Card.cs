using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mao
{
    class Card
    {
        public Card(Deck deck)
        {
            deck.DrawCard();
            CardValue = deck.CardValue; //The drawn cards' value is stored in the card class
            CardName = deck.CardName;   //The drawn cards' name is store in the card class as well
            CardSuit = deck.CardSuit;
        }
        //Declaration of properties
        public string CardName { get; } //Full card name (e.g "Ace of Spades")

        public int CardValue { get; set; }
        public string CardSuit { get; set; }
    }
}
