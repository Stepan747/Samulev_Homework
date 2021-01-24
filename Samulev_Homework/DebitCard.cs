using System;

namespace Samulev_TheBank
{
    public class DebitCard : Card
    {
        private Random random;

        public DebitCard()
        {
            BalanceCard = 0;
            random = new Random();

            for (int length = 0; length < NumberLength; length++)
            {
                Number += random.Next(0, 9).ToString();
            }
        }

        public override void ChooseActions()
        {
            Console.WriteLine(ConsoleConstants.MainActionsDebitCard);

            int personChoose;

            while (!int.TryParse(Console.ReadLine(), out personChoose)) ;

            switch (personChoose)
            {
                case 0:
                    return;
                case 1:
                    TransferMoneyToAccount();
                    break;
                case 2:
                    TransferMoneyToCard();
                    break;
                case 3:
                    SpendBalance();
                    break;
                default:
                    Console.WriteLine(ConsoleConstants.IncorrectInput);
                    break;
            }
        }       

        public override void TransferMoney()
        {       
            int transferMoney;
            int chooseTransfer;

            if (Account.Cards.Count > 0)
            {
                Console.WriteLine(ConsoleConstants.TranslationDiriction);
                while (!int.TryParse(Console.ReadLine(), out chooseTransfer)) ;

                if (chooseTransfer > 0 && chooseTransfer <= Account.Cards.Count)
                {
                    Console.WriteLine(ConsoleConstants.ChooseBalanceOrCard);

                    switch (chooseTransfer)
                    {
                        case 0:
                            while (!int.TryParse(Console.ReadLine(), out transferMoney)) ;
                            TransferMoneyToAccount();
                            break;
                        case 1:
                            while (!int.TryParse(Console.ReadLine(), out transferMoney)) ;
                            TransferMoneyToCard();
                            break;
                    }                  
                }
            }            
        }

        public override void TransferMoneyToCard()
        {
            int transferMoney;
            //Карта получателя
            int recipientsCard;     

            if (Account.Cards.Count > 0)
            {
                Console.WriteLine(ConsoleConstants.TranslationDiriction);
                while (!int.TryParse(Console.ReadLine(), out recipientsCard) && recipientsCard > 0) ;

                if (recipientsCard < Account.Cards.Count && this != Account.Cards[recipientsCard])
                {
                    Console.WriteLine(ConsoleConstants.InputSumm);

                    while (!int.TryParse(Console.ReadLine(), out transferMoney) && transferMoney > 0) ;

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
        }
    }
}