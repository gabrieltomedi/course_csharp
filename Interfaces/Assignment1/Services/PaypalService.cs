using System;

namespace Assignment1.Services
{
    internal class PaypalService : IOnlinePaymentService
    {
        private const double _feePercentage = 0.02;
        private const double _monthlyInterest = 0.01;

        public double PaymentFee(double amount)
        {
            return amount * _feePercentage;
        }

        public double Interest(double amount, int months)
        {
            return amount * _monthlyInterest * months;
        }
    }
}
