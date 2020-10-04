using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiPaymentDetails.Models;

namespace WebApiPaymentDetails.Data
{
    public class PaymentsContext : DbContext
    {
        public PaymentsContext(DbContextOptions<PaymentsContext> opt) : base(opt)
        {
        }

        public DbSet<Payment> Payments { get; set; }
    }
}
