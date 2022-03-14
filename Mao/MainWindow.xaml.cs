using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Links
//https://stackoverflow.com/questions/57146213/create-list-of-rectangles-with-properties

namespace Mao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double xPHandLocation = 150;                            //Sets the distance from the left where the hand is shown
        double xDHandLocation = 200;
        Deck deck = new Deck();                                 //Creates Deck
        //Player Card List
        List<Card> playerHand = new List<Card>();
        List<Button> playerVisibleHand = new List<Button>();
        //Dealer Card List
        List<Card> dealerHand = new List<Card>();
        List<Button> dealerVisibleHand = new List<Button>();
        //Board
        List<Card> cardsInPlay = new List<Card>();
        List<Button> visibleCardsInPlay = new List<Button>();
        public MainWindow()
        {
            InitializeComponent();
            GenerateTable();
        }
        //Populating the table with cards
        public void GenerateTable()
        { //General Rule Varaibles
            int handSize = 7;
            PlayerHand(handSize);
            DealerHand(handSize);
            CardsInPlay();
        }
        //Hand Methods
        //Takes card from the deck
        public void AddCard(string recipient, List<Card> hand, List<Button> visibleHand)
        {
            Card newCard = new Card(deck);                          //Card objects and information
            Button card = new Button() { Tag = newCard.CardName};   //Rectangle card representation
            hand.Add(newCard);                                      //Adding cards to hand
            visibleHand.Add(card);                                  //Adding rectangles to hand
            card.Style = (Style)FindResource("ButtonStyle");        //Removes default grey hover background
            string cardFilePath = @"..\..\images\cards\" + newCard.CardName + ".png";
            card.Height = 100;
            card.Width = 70;                            
            if (recipient == "player")                  //If Player Hand
            {
                //Card Position
                Canvas.SetTop(card, 180);                           //yLocation
                Canvas.SetLeft(card, xPHandLocation);               //xLocation
                xPHandLocation += 20;
                card.Click += Card_Click;                           //Card Logic
            }
            else if(recipient == "dealer") //If Dealer Hand
            {
                cardFilePath = @"..\..\images\cards\cardback.png";
                card.Height = 60;
                card.Width = 40;
                Canvas.SetTop(card, 10);
                Canvas.SetLeft(card, xDHandLocation);
                xDHandLocation += 20;
            }
            else if (recipient ==  "board") //Cards In Play
            {
                Canvas.SetTop(card, 80);
                Canvas.SetLeft(card, 350);
            }
            //Card Appearance
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(cardFilePath, UriKind.Relative));
            card.Background = imgBrush;
            table.Children.Add(card);                               //Adding the cards to the table
        }
        public void Redraw(List<Button> hand)
        {
            xPHandLocation = 150;
            //Delete current hand from display
            //Iterate hand, loop through and display cards
            foreach(Button b in hand)
            {
                table.Children.Remove(b);
            }
            foreach (Button b in hand)
            {
            Canvas.SetTop(b, 180);                           //yLocation
            Canvas.SetLeft(b, xPHandLocation);               //xLocation
            xPHandLocation += 20;
            table.Children.Add(b);
            }
        }
        //Initial population of player hand
        public void PlayerHand(int handSize)
        {

            string playerType = "player";
            for (int i = 0; i < handSize; i++)
            {
                AddCard(playerType, playerHand, playerVisibleHand);    
            }
        }
        //Initial population of dealer hand
        public void DealerHand(int handSize)
        {
            string playerType = "dealer";
            for (int i = 0; i < handSize; i++)
            {
                AddCard(playerType, dealerHand, dealerVisibleHand);
            }
        }
        public void CardsInPlay()
        {
            string playerType = "board";
            AddCard(playerType, cardsInPlay, visibleCardsInPlay);
        }
        private void Card_Click(object sender, RoutedEventArgs e)
        {
            var card = ((Button)sender).Tag;                        //Calls the tag/cardname given to the card button in the PlayerHand method
            bool valid = false;
            //Card Index Finder
            int index = -1;
            bool indexFound = false;
            do
            {
                index++;
                if (playerHand[index].CardName == card.ToString())
                {
                    indexFound = true;
                }
            } while (indexFound == false);
            //Card Placement Validation
            if (playerHand[index].CardValue == cardsInPlay[cardsInPlay.Count - 1].CardValue)//Card values equal
            {
                valid = true;
            }
            else if (playerHand[index].CardSuit == cardsInPlay[cardsInPlay.Count - 1].CardSuit)//Card suits equal
            {
                valid = true;
            }

            if (valid)
            {   //Moves the card from hand to the cards in play
                cardsInPlay.Add(playerHand[index]);
                visibleCardsInPlay.Add(playerVisibleHand[index]);
                playerHand.RemoveAt(index);
                Canvas.SetTop(visibleCardsInPlay[visibleCardsInPlay.Count - 1], 80);     //Sets played card position
                Canvas.SetLeft(visibleCardsInPlay[visibleCardsInPlay.Count - 1], 350);
                table.Children.Remove(playerVisibleHand[index]);
                table.Children.Add(visibleCardsInPlay[visibleCardsInPlay.Count - 1]);    //Adds card to the center of the board
                playerVisibleHand.Remove(playerVisibleHand[index]);
                Redraw(playerVisibleHand);                                               //Condensing hand
            }
            else
            {
                MessageBox.Show("Invalid");
            }
        }
        //Dealer AI
        private void btnDeck_Click(object sender, RoutedEventArgs e)
        {
            AddCard("player", playerHand, playerVisibleHand);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Redraw(playerVisibleHand);
        }
    }
}