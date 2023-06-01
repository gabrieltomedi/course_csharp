using Assignment1.Entities;
using Assignment1.Services;

namespace Assignment1.Services
{
    internal class ContractService
    {
        private IOnlinePaymentService _iOnlinePaymentServicce;

        public ContractService(IOnlinePaymentService iOnlinePaymentServicce)
        {
            _iOnlinePaymentServicce = iOnlinePaymentServicce;
        }

        public void processContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / months;

            for (int i = 1; i <= months; i++)
            {
                DateTime date = contract.Date.AddMonths(1);
                double updatedQuota = basicQuota + _iOnlinePaymentServicce.Interest(basicQuota, i);
                double fullQuota = updatedQuota + _iOnlinePaymentServicce.PaymentFee(updatedQuota);
                contract.AddInstallment(new Installment(date, fullQuota));
            }
        }
    }
}
