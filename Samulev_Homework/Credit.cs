namespace Samulev_TheBank
{
    public class Credit
    {
        public int CreditSumm { get; set; }

        public int CreditProcent { get; set; } = 10;

        public int CreditMonths { get; set; }

        public int CreditDebt { get; set; }

        public int MonthlyPayment { get; set; }

        public Credit(int summ, int month)
        {
            CreditSumm = summ;
            CreditMonths = month;
            MonthlyPayment = (summ + (int)(summ * (1 / CreditProcent))) / month;
            CreditDebt = 0;
        }

        public void LoanAccrual()
        {
            CreditDebt += MonthlyPayment;
            CreditMonths--;
        }

    }
}