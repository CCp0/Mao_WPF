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
        static double xLocation = 100;
        public MainWindow()
        {
            InitializeComponent();
            GenerateTable();
        }
        private void GenerateTable()
        {
            Deck deck = new Deck();
            List<Card> hand = new List<Card>();
            List<Rectangle> visibleHand = new List<Rectangle>();
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
            Rectangle card1 = new Rectangle() { Tag = newCard1.CardName };
            Rectangle card2 = new Rectangle() { Tag = newCard2.CardName };
            Rectangle card3 = new Rectangle() { Tag = newCard3.CardName };
            Rectangle card4 = new Rectangle() { Tag = newCard4.CardName };
            Rectangle card5 = new Rectangle() { Tag = newCard5.CardName };
            Rectangle card6 = new Rectangle() { Tag = newCard6.CardName };
            Rectangle card7 = new Rectangle() { Tag = newCard7.CardName };
            //Adding rectangles to hand
            visibleHand.Add(card1);
            visibleHand.Add(card2);
            visibleHand.Add(card3);
            visibleHand.Add(card4);
            visibleHand.Add(card5);
            visibleHand.Add(card6);
            visibleHand.Add(card7);
            //Styling the rectangles
            foreach (Rectangle card in visibleHand)
            {
                cardFilePath = @"..\..\images\cards\" + card.Tag +".png";
                card.Height = 100;
                card.Width = 70;
                card.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(cardFilePath, UriKind.Relative))
                };
                Canvas.SetTop(card, 150);
                Canvas.SetLeft(card, xLocation);
                xLocation += 20;
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
        private void btnPlayCard_Click(object sender, RoutedEventArgs e)
        {
            Rectangle test = new Rectangle();
            Button btn = new Button();
            test.Height = 100;
            test.Width = 70;
            test.Fill = new SolidColorBrush(System.Windows.Media.Colors.AliceBlue);
            //table.SetLeft(test, xLocation);
            Canvas.SetTop(test, 150);
            Canvas.SetLeft(test, xLocation);
            xLocation += 20;
            table.Children.Add(test);
        }
    }
}