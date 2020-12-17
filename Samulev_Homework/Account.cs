using System;
using System.Collections.Generic;

namespace Samulev_TheBank
{
    public class Account
    {
        public static int BalanceAccount { get; set; }

        public static List<Card> Cards;

        public void CheckCreditCards()
        {
            foreach (Card card in Cards)
            {
                if (card.TypeCard == ConsoleConstants.CreditCard)
                {
                    for (int countOfCredits = 0; countOfCredits < ((CreditCard)card).Credits.Count; countOfCredits++)
                    {
                        ((CreditCard)card).Credits[countOfCredits].LoanAccrual();
                    }
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

            BalanceAccount += balanceAccount;
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
