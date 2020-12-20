using System;
using System.Collections.Generic;

namespace Samulev_TheBank
{
    public class Account
    {
        public static int Balance { get; set; }

        public static List<Card> Cards;

        public void ActionsOnCards()
        {
            Console.WriteLine(ConsoleConstants.MainActionsAccount);

            int personChoose;

            while (! (Int32.TryParse(Console.ReadLine(), out personChoose))) ;

            switch (personChoose)
            {
                case 1:
                    CreateCard();
                    ActionsOnCards();
                    break;
                case 2:
                    OutputCards();
                    ActionsOnCards();
                    break;
                case 3:
                    TopUpBalance();
                    ActionsOnCards();
                    break;
                case 4:
                    ChooseCardTopUpBalance();
                    break;
                case 5:
                    ChooseCreditOrDebitCard();
                    break;
                default:
                    Console.WriteLine(ConsoleConstants.IncorrectInput);
                    break;
            }
        }

        public void ChooseCreditOrDebitCard()
        {
            Account account = new Account();

            CreditCard creditCard = new CreditCard();

            DebitCard debitCard = new DebitCard();

            Console.WriteLine(ConsoleConstants.ChooseCreditOrDebitCard);

            int personChoose;

            while (!(Int32.TryParse(Console.ReadLine(), out personChoose))) ;

            switch (personChoose)
            {
                case 0:
                    account.ActionsOnCards();
                    break;
                case 1:
                    creditCard.MainActionsOnCreditCard();
                    break;
                case 2:
                    debitCard.MainActionsOnDebitCard();
                    break;
                default:
                    Console.WriteLine(ConsoleConstants.IncorrectInput);
                    ChooseCreditOrDebitCard();
                    break;
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

            while (!Int32.TryParse(Console.ReadLine(), out chooseType)) ;

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
                    ActionsOnCards();
                    break;
            }
        }

        public void OutputCards()
        {
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

            while (!(Int32.TryParse(Console.ReadLine(), out balanceAccount)) && balanceAccount > 0);

            Balance += balanceAccount;
        }

        public void ChooseCardTopUpBalance()
        {
            Console.WriteLine(ConsoleConstants.CardNumber);

            int numberCardList;

            if (Cards.Count > 0)
            {                
                while (!(Int32.TryParse(Console.ReadLine(), out numberCardList))) ;

                if (numberCardList > 0 && numberCardList < Cards.Count)
                {
                    Cards[numberCardList - 1].TopUpCardBalance();
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
