using System;
using System.Collections.Generic;
using System.Text;

namespace Samulev_TheBank
{
    public class CreditCard : Card
    {
        public List<Credit> Credits;
        public CreditCard()
        {
            BalanceCard = 0;
            TypeCard = ConsoleConstants.CreditCard;
            Credits = new List<Credit>();
        }

        public void TakeLoan()
        {
            Console.WriteLine(ConsoleConstants.InputLoanSumm);

            int valueMonth;
            int loanSumm;

            while (!(Int32.TryParse(Console.ReadLine(), out valueMonth) && valueMonth > 0)) ;

            while (!(Int32.TryParse(Console.ReadLine(), out loanSumm) && loanSumm > 0)) ;          

            Credits.Add(new Credit(valueMonth, loanSumm));
        }

        public void PayCredit()
        {
            Console.WriteLine(ConsoleConstants.ChooseCreditCardNum);

            int numberCredit;
            int payCredit;
            int countCredit = 0;            

            while (!(Int32.TryParse(Console.ReadLine(), out numberCredit) && numberCredit >= 0)) ;

            foreach (Credit credit in Credits)
            {
                Console.WriteLine($"{countCredit++}. {ConsoleConstants.CreditDurationInMonths}{credit.CreditMonths}" +
                              $"{ConsoleConstants.LoanВebt}{credit.CreditSumm}");
            }

            if (numberCredit <= Credits.Count)
            {
                Console.WriteLine(ConsoleConstants.InputSumm);

                while (!(Int32.TryParse(Console.ReadLine(), out payCredit) && payCredit >= 0)) ;   
                
                if (payCredit <= Credits[numberCredit].CreditDebt && payCredit <= BalanceCard)
                {
                    Credits[numberCredit].CreditDebt -= payCredit;
                    BalanceCard -= payCredit;
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

        public bool CheckDebtCredit()
        {
            bool negativeCredit = false;

            foreach (Credit credit in Credits)
            {
                negativeCredit = true;
            }

            return negativeCredit;
        }

        public override void TransferMoney()
        {
            int transferMoney;
            int chooseTransfer;

            if (Account.Cards.Count > 0 && CheckDebtCredit() == false)
            {
                Console.WriteLine(ConsoleConstants.TranslationDiriction);
                while (!(Int32.TryParse(Console.ReadLine(), out chooseTransfer))) ;

                if (chooseTransfer > 0 && chooseTransfer <= Account.Cards.Count)
                {
                    Console.WriteLine(ConsoleConstants.ChooseBalanceOrCard);

                    switch (chooseTransfer)
                    {
                        case 0:
                            while (!(Int32.TryParse(Console.ReadLine(), out transferMoney))) ;
                            TransferMoneyToAccount();
                            break;
                        case 1:
                            while (!(Int32.TryParse(Console.ReadLine(), out transferMoney))) ;
                            TransferMoneyToCard();
                            break;
                    }
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

        public override void TransferMoneyToCard()
        {
            int transferMoney;
            //Карта получателя
            int recipientsCard;

            if (Account.Cards.Count > 0 && CheckDebtCredit() == false)
            {
                Console.WriteLine(ConsoleConstants.TranslationDiriction);
                while (!(Int32.TryParse(Console.ReadLine(), out recipientsCard) && recipientsCard > 0)) ;

                if (this != Account.Cards[recipientsCard])
                {
                    Console.WriteLine(ConsoleConstants.InputSumm);

                    while (!(Int32.TryParse(Console.ReadLine(), out transferMoney) && transferMoney > 0)) ;

                    if (BalanceCard >= transferMoney)
                    {
                        BalanceCard -= transferMoney;
                        Account.Cards[recipientsCard].BalanceCard += transferMoney;
                        Console.WriteLine(ConsoleConstants.CompliteOperation);
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
            else
            {
                Console.WriteLine(ConsoleConstants.IncorrectInput);
            }
        }
    }
}