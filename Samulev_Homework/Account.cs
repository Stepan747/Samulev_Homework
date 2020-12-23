using System;
using System.Collections.Generic;

namespace Samulev_TheBank
{
    public class Account
    {
        public static int Balance { get; set; }

        public static List<Card> Cards;

        public Account()
        {
            Cards = new List<Card>();
        }

        public void ActionsOnAccount()
        {
            int personChoose;

            while (true)
            {
                Console.WriteLine(ConsoleConstants.MainActionsAccount);

                while (!int.TryParse(Console.ReadLine(), out personChoose)) ;

                switch (personChoose)
                {
                    case 1:
                        CreateCard();
                        break;
                    case 2:
                        OutputCards();
                        break;
                    case 3:
                        TopUpBalance();
                        break;
                    case 4:
                        ChooseCardTopUpBalance();
                        break;
                    case 5:
                        ChooseCardForActions();
                        break;
                    default:
                        Console.WriteLine(ConsoleConstants.IncorrectInput);
                        break;
                }
            }
        }

        public void ChooseCardForActions()
        {
            if (Cards.Count == 0)
            {
                Console.WriteLine(ConsoleConstants.NoneCards);
                return;
            }

            int cardCount = 0;

            foreach (Card card in Cards)
            {
                Console.WriteLine($"{cardCount++} {card.Number}");
            }

            int chooseCard;

            while (!int.TryParse(Console.ReadLine(), out chooseCard)) ;

            if (chooseCard > (Cards.Count - 1)) 
            {
                Console.WriteLine(ConsoleConstants.IncorrectInput);
                return;
            }
            else if (Cards[chooseCard] as DebitCard != null)
            {
                ((DebitCard)Cards[chooseCard]).MainActionsOnDebitCard();
            }
            else
            {
                ((CreditCard)Cards[chooseCard]).MainActionsOnCreditCard();
            }
        }

        public void CheckCreditCards()
        {
            foreach (Card card in Cards)
            {
                if (card as CreditCard != null)
                {
                    for (int countOfCredits = 0; countOfCredits < ((CreditCard)card).Credits.Count; countOfCredits++)
                    {
                        Console.WriteLine(ConsoleConstants.CompliteOperation);
                        ((CreditCard)card).Credits[countOfCredits].LoanAccrual();
                    }
                }
                else
                {
                    Console.WriteLine(ConsoleConstants.IncorrectInput);
                }
            }
        }

        public void CreateCard()
        {
            Console.WriteLine(ConsoleConstants.CreateCard);
            Console.WriteLine(ConsoleConstants.TypeCards);

            int chooseType;

            while (!int.TryParse(Console.ReadLine(), out chooseType)) ;

            switch (chooseType)
            {
                case 0:
                    Cards.Add(new DebitCard());
                    break;
                case 1:
                    Cards.Add(new CreditCard());
                    break;
                default:
                    Console.WriteLine(ConsoleConstants.IncorrectInput);
                    ActionsOnAccount();
                    break;
            }
        }

        public void OutputCards()
        {
            if (Cards.Count == 0)
            {
                Console.WriteLine(ConsoleConstants.NoneCards);
                return;
            }

            int countCards = 0;

            foreach (Card card in Cards)
            {
                Console.WriteLine($"{countCards++}. {ConsoleConstants.CardNumber}{card.Number}" +
                                  $"{ConsoleConstants.CardBalance}{card.BalanceCard}");
            }
        }

        public void TopUpBalance()
        {
            Console.WriteLine(ConsoleConstants.InputSumm);

            int balanceAccount;

            while (!int.TryParse(Console.ReadLine(), out balanceAccount) && balanceAccount > 0);

            Balance += balanceAccount;

            Console.WriteLine(Balance);
        }

        public void ChooseCardTopUpBalance()
        {
            Console.WriteLine(ConsoleConstants.CardNumber);

            int cardCount = 0;

            foreach (Card card in Cards)
            {
                Console.WriteLine($"{cardCount++} {card.Number}");
            }

            int numberCardList;

            if (Cards.Count > 0)
            {                
                while (!int.TryParse(Console.ReadLine(), out numberCardList)) ;

                if (numberCardList >= 0 && numberCardList < Cards.Count)
                {
                    Cards[numberCardList].TopUpCardBalance();
                }
                else
                {
                    Console.WriteLine(ConsoleConstants.IncorrectInput);
                }
            }
            else
            {
                Console.WriteLine(ConsoleConstants.IncorrectInput);
            }
        }
    }
}
