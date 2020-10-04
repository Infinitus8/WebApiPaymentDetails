using System.Collections.Generic;
using WebApiPaymentDetails.Models;

namespace WebApiPaymentDetails.Data
{
    public interface IPaymentsRepo
    {
        void AddPayment(Payment pm);
        void DeletePayment(Payment pm);
        Payment GetPaymentById(int id);
        IEnumerable<Payment> GetPayments();
        bool SaveChanges();
        void UpdatePayment(Payment pm);
    }
}