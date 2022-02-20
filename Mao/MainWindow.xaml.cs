﻿using System;
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
        List<Card> pHand = new List<Card>();
        List<Button> pVisibleHand = new List<Button>();
        //Dealer Card List
        List<Card> dHand = new List<Card>();
        List<Button> dVisibleHand = new List<Button>();
        //Board
        List<Card> cardsInPlay = new List<Card>();
        List<Button> visibleCardsInPlay = new List<Button>();
        public MainWindow()
        {
            InitializeComponent();
            GenerateTable();
        }
        public void GenerateTable()
        { //General Rule Varaibles
            int handSize = 7;
            PlayerHand(handSize);
            DealerHand(handSize);
            CardsInPlay();
        }
        //Hand Methods
        public void AddCard(int recipient, List<Card> hand, List<Button> visibleHand)
        {
            Card newCard = new Card(deck);                          //Card objects and information
            Button card = new Button() { Tag = newCard.CardName};   //Rectangle card representation
            hand.Add(newCard);                                      //Adding cards to hand
            visibleHand.Add(card);                                  //Adding rectangles to hand
            string cardFilePath = @"..\..\images\cards\" + newCard.CardName + ".png";
            if (recipient == 1)     //If Player Hand
            {
                card.Height = 100;
                card.Width = 70;
                //Card Position
                Canvas.SetTop(card, 180);
                Canvas.SetLeft(card, xPHandLocation);
                xPHandLocation += 20;
                card.Click += Card_Click;                           //Card Logic
            }
            else if(recipient == 2) //If Dealer Hand
            {
                cardFilePath = @"..\..\images\cards\cardback.png";
                card.Height = 60;
                card.Width = 40;
                Canvas.SetTop(card, 10);
                Canvas.SetLeft(card, xDHandLocation);
                xDHandLocation += 20;
            }
            else if (recipient == 3) //Cards In Play
            {
                card.Height = 95;
                card.Width = 65;
                Canvas.SetTop(card, 80);
                Canvas.SetLeft(card, 350);
            }
            //Card Appearance
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(cardFilePath, UriKind.Relative));
            card.Background = imgBrush;
            table.Children.Add(card);                               //Adding the cards to the table
        }
        public void PlayerHand(int handSize)
        {
            int recipient = 1;
            for (int i = 0; i < handSize; i++)
            {
                AddCard(recipient, pHand, pVisibleHand);
            }
        }
        public void DealerHand(int handSize)
        {
            int recipient = 2;
            for (int i = 0; i < handSize; i++)
            {
                AddCard(recipient, dHand, dVisibleHand);
            }
        }
        public void CardsInPlay()
        {
            int recipient = 3;
            AddCard(recipient, cardsInPlay, visibleCardsInPlay);
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
                if (pHand[index].CardName == card.ToString())
                {
                    indexFound = true;
                }
            } while (indexFound == false);
            //Card Placement Validation
            if (pHand[index].CardValue == cardsInPlay[cardsInPlay.Count - 1].CardValue)//Card values equal
            {
                valid = true;
            }
            else if (pHand[index].CardSuit == cardsInPlay[cardsInPlay.Count - 1].CardSuit)//Card suits equal
            {
                valid = true;
            }

            if (valid)
            {   //Moves the card from hand to the cards in play
                cardsInPlay.Add(pHand[index]);
                visibleCardsInPlay.Add(pVisibleHand[index]);
                pHand.RemoveAt(index);
                table.Children.Remove(pVisibleHand[index]);
                pVisibleHand.Remove(pVisibleHand[index]);
            }
            else
            {
                MessageBox.Show("Invalid");
            }
        }
        private void btnDeck_Click(object sender, RoutedEventArgs e)
        {
            AddCard(1, pHand, pVisibleHand);
        }
    }
}