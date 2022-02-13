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
        public MainWindow()
        {
            InitializeComponent();
            GenerateTable();
        }
        public void GenerateTable()
        {
            PlayerHand();
            DealerHand();
            CardsInPlay();
        }
        //Hand Methods
        public void PlayerHand()
        {
            List<Card> hand = new List<Card>();
            List<Button> visibleHand = new List<Button>();
            string cardFilePath;
            //Card objects and information
            Card newCard1 = new Card(deck);
            Card newCard2 = new Card(deck);
            Card newCard3 = new Card(deck);
            Card newCard4 = new Card(deck);
            Card newCard5 = new Card(deck);
            Card newCard6 = new Card(deck);
            Card newCard7 = new Card(deck);
            //Adding cards to hand
            hand.Add(newCard1);
            hand.Add(newCard2);
            hand.Add(newCard3);
            hand.Add(newCard4);
            hand.Add(newCard5);
            hand.Add(newCard6);
            hand.Add(newCard7);
            //Rectangle card representation
            Button card1 = new Button() { Tag = newCard1.CardName };
            Button card2 = new Button() { Tag = newCard2.CardName };
            Button card3 = new Button() { Tag = newCard3.CardName };
            Button card4 = new Button() { Tag = newCard4.CardName };
            Button card5 = new Button() { Tag = newCard5.CardName };
            Button card6 = new Button() { Tag = newCard6.CardName };
            Button card7 = new Button() { Tag = newCard7.CardName };
            //Adding rectangles to hand
            visibleHand.Add(card1);
            visibleHand.Add(card2);
            visibleHand.Add(card3);
            visibleHand.Add(card4);
            visibleHand.Add(card5);
            visibleHand.Add(card6);
            visibleHand.Add(card7);
            //Styling the visible cards
            foreach (Button card in visibleHand)
            {
                //Card Appearance
                cardFilePath = @"..\..\images\cards\" + card.Tag + ".png";
                card.Height = 100;
                card.Width = 70;
                ImageBrush imgBrush = new ImageBrush();
                imgBrush.ImageSource = new BitmapImage(new Uri(cardFilePath, UriKind.Relative));
                card.Background = imgBrush;
                //Card Position
                Canvas.SetTop(card, 180);
                Canvas.SetLeft(card, xPHandLocation);
                xPHandLocation += 20;
                //Card Logic
                card.Click += Card_Click;
            }
            //Adding the cards to the table
            table.Children.Add(card1);
            table.Children.Add(card2);
            table.Children.Add(card3);
            table.Children.Add(card4);
            table.Children.Add(card5);
            table.Children.Add(card6);
            table.Children.Add(card7);
        }
        public void DealerHand()
        {//Pretty much same logic as PlayerHand() with changes to the display (Cannt see dealers hand)
            List<Card> hand = new List<Card>();
            List<Button> visibleHand = new List<Button>();
            //Card objects and information
            Card newCard1 = new Card(deck);
            Card newCard2 = new Card(deck);
            Card newCard3 = new Card(deck);
            Card newCard4 = new Card(deck);
            Card newCard5 = new Card(deck);
            Card newCard6 = new Card(deck);
            Card newCard7 = new Card(deck);
            //Adding cards to hand
            hand.Add(newCard1);
            hand.Add(newCard2);
            hand.Add(newCard3);
            hand.Add(newCard4);
            hand.Add(newCard5);
            hand.Add(newCard6);
            hand.Add(newCard7);
            //Rectangle card representation
            Button card1 = new Button() { Tag = newCard1.CardName };
            Button card2 = new Button() { Tag = newCard2.CardName };
            Button card3 = new Button() { Tag = newCard3.CardName };
            Button card4 = new Button() { Tag = newCard4.CardName };
            Button card5 = new Button() { Tag = newCard5.CardName };
            Button card6 = new Button() { Tag = newCard6.CardName };
            Button card7 = new Button() { Tag = newCard7.CardName };
            //Adding rectangles to hand
            visibleHand.Add(card1);
            visibleHand.Add(card2);
            visibleHand.Add(card3);
            visibleHand.Add(card4);
            visibleHand.Add(card5);
            visibleHand.Add(card6);
            visibleHand.Add(card7);
            //Styling the rectangles
            foreach (Button card in visibleHand)
            {
                string cardFilePath = @"..\..\images\cards\cardback.png";
                card.Height = 60;
                card.Width = 40;
                ImageBrush imgBrush = new ImageBrush();
                imgBrush.ImageSource = new BitmapImage(new Uri(cardFilePath, UriKind.Relative));
                card.Background = imgBrush;
                Canvas.SetTop(card, 10);
                Canvas.SetLeft(card, xDHandLocation);
                xDHandLocation += 20;
            }
            //Adding the cards to the table
            table.Children.Add(card1);
            table.Children.Add(card2);
            table.Children.Add(card3);
            table.Children.Add(card4);
            table.Children.Add(card5);
            table.Children.Add(card6);
            table.Children.Add(card7);
        }
        public void CardsInPlay()
        {
            List<Card> cards = new List<Card>();
        }
        private void Card_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}