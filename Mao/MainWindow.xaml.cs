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
        double xPHandLocation = 150;//Sets the distance from the left where the hand is shown
        double xDHandLocation = 200;
        Deck deck = new Deck();//Creates Deck
        //Player Card List
        List<Card> pHand = new List<Card>();
        List<Button> pVisibleHand = new List<Button>();
        //Dealer Card List
        List<Card> dHand = new List<Card>();
        List<Button> dVisibleHand = new List<Button>();
        //Board
        List<Card> cardsInPlay = new List<Card>();
        public MainWindow()
        {
            InitializeComponent();
            GenerateTable();
        }
        public void GenerateTable()
        {
            //General Rule Varaibles
            int handSize = 7;
            PlayerHand(handSize);
            DealerHand(handSize);
            CardsInPlay();
        }
        //Hand Methods
        public void AddCard(bool player, List<Card> hand, List<Button> visibleHand)
        {
            string cardFilePath = @"..\..\images\cards\cardback.png"; ;
            //Card objects and information
            Card newCard = new Card(deck);
            //Rectangle card representation
            Button card = new Button() { Tag = newCard.CardName};
            hand.Add(newCard);//Adding cards to hand
            visibleHand.Add(card);//Adding rectangles to hand
            if (player == true) //If Player Hand
            {
                cardFilePath = @"..\..\images\cards\" + card.Tag + ".png";
                card.Height = 100;
                card.Width = 70;
                //Card Position
                Canvas.SetTop(card, 180);
                Canvas.SetLeft(card, xPHandLocation);
                xPHandLocation += 20;
                //Card Logic
                card.Click += Card_Click;
            }
            else if(player == false) //If Dealer Hand
            {
                card.Height = 60;
                card.Width = 40;
                Canvas.SetTop(card, 10);
                Canvas.SetLeft(card, xDHandLocation);
                xDHandLocation += 20;
            }
            //Card Appearance
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(cardFilePath, UriKind.Relative));
            card.Background = imgBrush;
            //Adding the cards to the table
            table.Children.Add(card);
        }
        public void PlayerHand(int handSize)
        {
            bool player = true;
            for (int i = 0; i < handSize; i++)
            {
                AddCard(player, pHand, pVisibleHand);
            }
        }
        public void DealerHand(int handSize)
        {
            bool player = false;
            for (int i = 0; i < handSize; i++)
            {
                AddCard(player, dHand, dVisibleHand);
            }
        }
        public void CardsInPlay()
        {
            //AddCard();
        }
        private void Card_Click(object sender, RoutedEventArgs e)
        {
            var card = ((Button)sender).Tag;//Calls the tag/cardname given to the card button in the PlayerHand method
            bool valid = false;
            MessageBox.Show(card.ToString());
            //if(card == cardsInPlay[cardsInPlay.Count])//Card value
            //{
            //    valid = true;
            //}
            //else if(card == cardsInPlay[cardsInPlay.Count])//Card suit
            //{
            //    valid = true;
            //}
        }
    }
}