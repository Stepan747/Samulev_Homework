using System;

namespace Samulev_TheBank
{

    class Program
    {

        public static void Main(string[] args)
        {
            Account account = new Account();
            while (true)
            {
                int personChoose;

                ConsoleProvider.ShowMessage(ConsoleConstants.MainActionsAccount);

                while (!int.TryParse(Console.ReadLine(), out personChoose)) ;

                switch (personChoose)
                {
                    case 1:
                        account.CreateCard();
                        break;
                    case 2:
                        account.OutputCards();
                        break;
                    case 3:
                        account.TopUpBalance();
                        break;
                    case 4:
                        account.ChooseCardTopUpBalance();
                        break;
                    case 5:
                        account.ChooseCardForActions();
                        break;
                    default:
                        Console.WriteLine(ConsoleConstants.IncorrectInput);
                        break;
                }
            }
        }

        public static class ConsoleProvider
        {
            public const string IncorrectInput = "incorrect input";

            public static void ShowMessage(string message)
            {
                Console.WriteLine(message);
            }

            public static int InputValue(int maxValue)
            {
                int inputValue;

                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out inputValue))
                    {
                        return inputValue;
                    }
                    else
                    {
                        Console.WriteLine(IncorrectInput);
                    }
                }
            }
        }
    }
}
