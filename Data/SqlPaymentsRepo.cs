using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPaymentDetails.Models;

namespace WebApiPaymentDetails.Data
{
    public class SqlPaymentsRepo : IPaymentsRepo
    {
        private readonly PaymentsContext _context;

        public SqlPaymentsRepo(PaymentsContext context)
        {
            _context = context;
        }

        public void AddPayment(Payment pm)
        {
            if (pm == null)
            {
                throw new ArgumentNullException(nameof(pm));
            }

            _context.Payments.Add(pm);
        }

        public void DeletePayment(Payment pm)
        {
            if (pm == null)
            {
                throw new ArgumentNullException(nameof(pm));
            }

            _context.Payments.Remove(pm);
        }

        public IEnumerable<Payment> GetPayments()
        {
            return _context.Payments.ToList();
        }

        public Payment GetPaymentById(int id)
        {
            return _context.Payments.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdatePayment(Payment pm)
        {
            //Nothing
        }
    }
}
