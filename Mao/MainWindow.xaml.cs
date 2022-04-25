using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

//Links
//https://stackoverflow.com/questions/57146213/create-list-of-rectangles-with-properties

namespace Mao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string errFilePath = "../ErrorLog.txt";
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
        Card topCard;

        //Changable variables for rules
        int finalCard = 1, semiFinalCard = 2, streak = 0;       //Sets when player has to click mao or mao mao and the players' win streak
        bool mao = false, maoMao = false;                       //Bools to help check if the button press of mao or mao mao is appropriate
        int handSize = 7;                                       //Sets the handSize
        public MainWindow()
        {
            InitializeComponent();
            GenerateTable();
            lblStreak.Content = streak;
        }
        //Populating the table with cards
        public void GenerateTable()
        { //General Rule Varaibles
            try
            {
                deck.Shuffle();
                PlayerHand(handSize);
                DealerHand(handSize);
                CardsInPlay();
            }
            catch (Exception err)
            {
                MessageBox.Show("The following error has occurred: " + err.Message);
                string text = "\n" + DateTime.Now + " " + err.Message;
                File.AppendAllText(errFilePath, text);
            }
        }
        //Hand Methods
        //Takes card from the deck
        public void AddCard(string recipient, List<Card> hand, List<Button> visibleHand)
        {
            try
            {
                if (playerHand.Count + dealerHand.Count + cardsInPlay.Count == 51)//If all cards in the deck are exhausted
                {
                    topCard = cardsInPlay[cardsInPlay.Count - 1];
                    deck.RefreshDeck(cardsInPlay);                      //Take cards in play and add to deck
                    cardsInPlay.Clear();
                    cardsInPlay.Add(topCard);
                }
                Card newCard = deck.GetNextCard();                      //Card objects and information
                Button card = new Button() { Tag = newCard.CardName };   //Rectangle card representation
                hand.Add(newCard);                                      //Adding cards to hand
                visibleHand.Add(card);                                  //Adding rectangles to hand
                card.Style = (Style)FindResource("ButtonStyle");        //Removes default grey hover background
                string cardFilePath = @"..\..\images\cards\" + newCard.CardName + ".png";
                card.Height = 100;
                card.Width = 70;
                if (recipient == "player")                              //If Player Hand
                {
                    //Card Position
                    Canvas.SetTop(card, 180);                           //yLocation
                    Canvas.SetLeft(card, xPHandLocation);               //xLocation
                    xPHandLocation += 20;
                    card.Click += Card_Click;                           //Card Logic
                }
                else if (recipient == "dealer") //If Dealer Hand
                {
                    cardFilePath = @"..\..\images\cards\cardback.png";
                    card.Height = 60;
                    card.Width = 40;
                    Canvas.SetTop(card, 10);
                    Canvas.SetLeft(card, xDHandLocation);
                    xDHandLocation += 20;
                }
                else if (recipient == "board") //Cards In Play
                {
                    Canvas.SetTop(card, 80);
                    Canvas.SetLeft(card, 350);
                }
                //Card Appearance
                CardImage(card, cardFilePath);
                table.Children.Add(card);                               //Adding the cards to the table
            }
            catch (Exception err)
            {
                MessageBox.Show("The following error has occurred: " + err.Message);
                string text = "\n" + DateTime.Now + " " + err.Message;
                File.AppendAllText(errFilePath, text);
            }
        }
        //Rebuilds the cards displayed to display in sequence
        public void Redraw(string player, List<Button> hand)
        {
            try
            {
                double xHandLocation = 0, yHandLocation = 0;
                switch (player)
                {
                    case "player":
                        xPHandLocation = 150;
                        xHandLocation = xPHandLocation;
                        yHandLocation = 180;
                        break;
                    case "dealer":
                        xDHandLocation = 200;
                        xHandLocation = xDHandLocation;
                        yHandLocation = 10;
                        break;
                }
                foreach (Button b in hand)//Delete current hand from display
                {
                    table.Children.Remove(b);
                }
                foreach (Button b in hand)//Iterate hand, loop through and display cards
                {
                    Canvas.SetTop(b, yHandLocation);                           //yLocation
                    Canvas.SetLeft(b, xHandLocation);                          //xLocation
                    xHandLocation += 20;
                    table.Children.Add(b);
                }
                if (player == "player")
                {
                    xPHandLocation = xHandLocation;
                }
                else
                {
                    xDHandLocation = xHandLocation;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("The following error has occurred: " + err.Message);
                string text = "\n" + DateTime.Now + " " + err.Message;
                File.AppendAllText(errFilePath, text);
            }
        }
        //Initial population of player hand
        public void PlayerHand(int handSize)
        {
            try
            {
                string playerType = "player";
                for (int i = 0; i < handSize; i++)
                {
                    AddCard(playerType, playerHand, playerVisibleHand);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("The following error has occurred: " + err.Message);
            }
        }
        //Initial population of dealer hand
        public void DealerHand(int handSize)
        {
            try
            {
                string playerType = "dealer";
                for (int i = 0; i < handSize; i++)
                {
                    AddCard(playerType, dealerHand, dealerVisibleHand);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("The following error has occurred: " + err.Message);
                string text = "\n" + DateTime.Now + " " + err.Message;
                File.AppendAllText(errFilePath, text);
            }
        }
        //Sets up the first card in the center of the board
        public void CardsInPlay()
        {
            try
            {
                string playerType = "board";
                AddCard(playerType, cardsInPlay, visibleCardsInPlay);
            }
            catch (Exception err)
            {
                MessageBox.Show("The following error has occurred: " + err.Message);
                string text = "\n" + DateTime.Now + " " + err.Message;
                File.AppendAllText(errFilePath, text);
            }
        }
        //Plays card from hand if it passes the logic
        public void Card_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var card = ((Button)sender).Tag;                        //Calls the tag/cardname given to the card button in the PlayerHand method
                bool valid = false;
                //Card Index Finder
                int index = -1;
                bool indexFound = false;
                string penaltyName = "disorderly placement";
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
                    valid = PenaltyForMao(valid);
                    if(valid == false)
                    {
                        penaltyName = "mao";
                    }
                }
                else if (playerHand[index].CardSuit == cardsInPlay[cardsInPlay.Count - 1].CardSuit)//Card suits equal
                {
                    valid = PenaltyForMao(valid);
                    if (valid == false)
                    {
                        penaltyName = "mao";
                    }
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
                    Redraw("player", playerVisibleHand);                                     //Condensing hand
                }
                else
                {
                    MessageBox.Show("Penalty for " + penaltyName);
                    AddCard("player", playerHand, playerVisibleHand);
                }
                WinCheck();
                //Dealers Turn
                DealerAI();
            }
            catch (Exception err)
            {
                MessageBox.Show("The following error has occurred: " + err.Message);
                string text = "\n" + DateTime.Now + " " + err.Message;
                File.AppendAllText(errFilePath, text);
            }
        }
        //All dealer logic for the dealers' play turn
        public void DealerAI()
        {
            int index = -1;
            bool valid = false;
            try
            {
                do
                {
                    index++;
                    if (dealerHand[index].CardSuit == cardsInPlay[cardsInPlay.Count - 1].CardSuit || dealerHand[index].CardValue == cardsInPlay[cardsInPlay.Count - 1].CardValue)
                    {
                        //Flipping and resizing dealer card
                        string cardFilePath = @"..\..\images\cards\" + dealerHand[index].CardName + ".png";
                        dealerVisibleHand[index].Height = 100;
                        dealerVisibleHand[index].Width = 70;
                        CardImage(dealerVisibleHand[index], cardFilePath);
                        //Moves the card from hand to the cards in play
                        cardsInPlay.Add(dealerHand[index]);
                        visibleCardsInPlay.Add(dealerVisibleHand[index]);
                        dealerHand.RemoveAt(index);
                        Canvas.SetTop(visibleCardsInPlay[visibleCardsInPlay.Count - 1], 80);     //Sets played card position
                        Canvas.SetLeft(visibleCardsInPlay[visibleCardsInPlay.Count - 1], 350);
                        table.Children.Remove(dealerVisibleHand[index]);
                        table.Children.Add(visibleCardsInPlay[visibleCardsInPlay.Count - 1]);    //Adds card to the center of the board
                        dealerVisibleHand.Remove(dealerVisibleHand[index]);
                        valid = true;
                        Redraw("dealer", dealerVisibleHand);                                     //Condensing hand
                    }
                }
                while (valid == false && index != dealerHand.Count - 1);
                if (valid == false)//If dealer couldn't place draw a card
                {
                    AddCard("dealer", dealerHand, dealerVisibleHand);
                }
                mao = false;    //Mao and mao mao buttons are reset for the player
                maoMao = false;
                WinCheck();
            }
            catch (Exception err)
            {
                MessageBox.Show("The following error has occurred: " + err.Message);
                string text = "\n" + DateTime.Now + " " + err.Message;
                File.AppendAllText(errFilePath, text);
            }
        }
        //Draws a card when the deck is clicked
        private void btnDeck_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddCard("player", playerHand, playerVisibleHand);
                DealerAI();
            }
            catch (Exception err)
            {
                MessageBox.Show("The following error has occurred: " + err.Message);
                string text = "\n" + DateTime.Now + " " + err.Message;
                File.AppendAllText(errFilePath, text);
            }
        }
        //Passes a rule check 
        private void btnMao_Click(object sender, RoutedEventArgs e)
        {
            mao = true;                                                 //Changes mao to true, this will be dealt with in the card_click method when playing the last card
            if(playerHand.Count != finalCard)                           //Penalty for pressing the button at the wrong time
            {
                MessageBox.Show("Penalty for mao");
                AddCard("player", playerHand, playerVisibleHand);
            }
        }
        //Passes a rule check
        private void btnMaoMao_Click(object sender, RoutedEventArgs e)
        {
            maoMao = true;                                              //Same as above but using maoMao
            if (playerHand.Count != semiFinalCard)
            {
                MessageBox.Show("Penalty for mao");
                AddCard("player", playerHand, playerVisibleHand);
            }
        }
        //Displays the leaderboard window
        private void btnLeaderboard_Click(object sender, RoutedEventArgs e)
        {
            LeaderboardPopUp leaderboardWindow = new LeaderboardPopUp();
            leaderboardWindow.Show();
        }
        //Sets the image of a xaml card button
        private void CardImage(Button card, string cardFilePath)
        {
            try
            {
                ImageBrush imgBrush = new ImageBrush();
                imgBrush.ImageSource = new BitmapImage(new Uri(cardFilePath, UriKind.Relative));
                card.Background = imgBrush;
            }
            catch (Exception err)
            {
                MessageBox.Show("The following error has occurred: " + err.Message);
                string text = "\n" + DateTime.Now + " " + err.Message;
                File.AppendAllText(errFilePath, text);
            }
        }
        //Surrenders game
        private void btnConcede_Click(object sender, RoutedEventArgs e)
        {
            WinCheck(true);
        }
        //Events for win and loss
        public void WinCheck(bool concede = false)
        {
            try
            {
                if (playerHand.Count == 0)
                {
                    streak++;
                    lblStreak.Content = streak;
                    MessageBox.Show("Congrats you won!!! Time for the next round");
                    //Changes the rules around a bit
                    ValueChanger();
                    //Clear board
                    playerHand.Clear();
                    playerVisibleHand.Clear();
                    dealerHand.Clear();
                    dealerVisibleHand.Clear();
                    cardsInPlay.Clear();
                    visibleCardsInPlay.Clear();
                    //Board reset
                    deck.InitializeDeck();
                    GenerateTable();
                }
                else if (dealerHand.Count == 0 || concede == true)
                {
                    MessageBox.Show("Bummer, you lost. Time for the next round");
                    InputPlayerDetails inputPlayerWindow = new InputPlayerDetails();
                    inputPlayerWindow.Show();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("The following error has occurred: " + err.Message);
                string text = "\n" + DateTime.Now + " " + err.Message;
                File.AppendAllText(errFilePath, text);
            }
        }
        //Game changing methods
        private void ValueChanger()
        {
            try
            {
                Random rnd = new Random();
                int ruleChange = rnd.Next(0, 3);
                switch (ruleChange)
                {
                    case 0:
                        handSize = rnd.Next(5, 12);
                        break;
                    case 1:
                        finalCard = rnd.Next(1, 4);
                        break;
                    case 2:
                        semiFinalCard = rnd.Next(2, 5);
                        break;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("The following error has occurred: " + err.Message);
                string text = "\n" + DateTime.Now + " " + err.Message;
                File.AppendAllText(errFilePath, text);
            }
        }
        //Penalty methods
        private bool PenaltyForMao(bool valid)
        {
            try
            {
                if ((playerHand.Count == finalCard && mao) || (playerHand.Count == semiFinalCard && maoMao))//If its the last or second last card
                {
                    valid = true;
                }
                else if (playerHand.Count != semiFinalCard && playerHand.Count != finalCard)
                {
                    valid = true; //For every card that isnt the mao/last cards
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("The following error has occurred: " + err.Message);
                string text = "\n" + DateTime.Now + " " + err.Message;
                File.AppendAllText(errFilePath, text);
            }
            return valid;
        }
    }
}