using System;

namespace Samulev_TheBank
{
    public abstract class Card
    {
        public const int NumberLength = 16;

        public string Number { get; protected set; }

        public int BalanceCard { get; set; }

        public string TypeCard { get; protected set; }

        public void TopUpCardBalance()
        {
            Console.WriteLine(ConsoleConstants.AccountBalance + Account.Balance);

            Console.WriteLine(ConsoleConstants.InputSumm);

            int transferToCard;

            while (!int.TryParse(Console.ReadLine(), out transferToCard)) ;

            if (transferToCard > 0 && transferToCard <= Account.Balance)
            {
                BalanceCard += transferToCard;
                Account.Balance -= transferToCard;

                Console.WriteLine(ConsoleConstants.CompliteOperation);
            }
            else
            {
                Console.WriteLine(ConsoleConstants.IncorrectInput);
            }
        }

        public void TransferMoneyToAccount()
        {
            Console.WriteLine(ConsoleConstants.InputNumberAccount);

            string numberAccount = Console.ReadLine();

            if (numberAccount.Length != ConsoleConstants.LengthNomberAccount)
            {
                Console.WriteLine(ConsoleConstants.IncorrectInput);
            }
            else
            {
                Console.WriteLine(ConsoleConstants.InputSumm);

                int howMoney;

                while (!int.TryParse(Console.ReadLine(), out howMoney)) ;

                if (howMoney < 0 || howMoney > BalanceCard)
                {
                    Console.WriteLine(ConsoleConstants.IncorrectInput);
                }
                else
                {
                    BalanceCard -= howMoney;
                    Account.Balance += howMoney;
                    Console.WriteLine(ConsoleConstants.CompliteOperation);
                }
            }
        }
        public void SpendBalance()
        {
            Console.WriteLine(ConsoleConstants.InputSumm);

            int inputSumm;

            while (!int.TryParse(Console.ReadLine(), out inputSumm)) ;

            if (inputSumm > 0 & inputSumm <= BalanceCard)
            {
                Console.WriteLine(ConsoleConstants.CompliteOperation);
                BalanceCard -= inputSumm;
            }
            else
            {
                Console.WriteLine(ConsoleConstants.IncorrectInput);
            }
        }

        public abstract void TransferMoneyToCard();

        public abstract void TransferMoney();

        public abstract void ChooseActions();
    }
}