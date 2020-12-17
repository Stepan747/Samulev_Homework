﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Samulev_TheBank
{
    public class DebitCard : Card
    {
        public DebitCard()
        {
            BalanceCard = 0;
            TypeCard = ConsoleConstants.DebitCard;
        }

        public override void TransferMoney()
        {       
            int transferMoney;
            int chooseTransfer;

            if (Account.Cards.Count > 0)
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
        }
    }
}