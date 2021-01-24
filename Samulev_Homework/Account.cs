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

            if (chooseCard > (Cards.Count + 1)) 
            {
                Console.WriteLine(ConsoleConstants.IncorrectInput);
                return;
            }
            else if (Cards[chooseCard] as DebitCard != null)
            {
                ((DebitCard)Cards[chooseCard]).ChooseActions();
            }
            else
            {
                ((CreditCard)Cards[chooseCard]).ChooseActions();
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
            Console.WriteLine(ConsoleConstants.AccountBalance + Balance);

            Console.WriteLine(ConsoleConstants.InputSumm);

            int balanceAccount;

            while (!int.TryParse(Console.ReadLine(), out balanceAccount) && balanceAccount > 0);

            Balance += balanceAccount;

            Console.WriteLine(ConsoleConstants.CompliteOperation + ConsoleConstants.AccountBalance + Balance);
        }

        public void ChooseCardTopUpBalance()
        {
            Console.WriteLine(ConsoleConstants.AccountBalance + Balance);

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
