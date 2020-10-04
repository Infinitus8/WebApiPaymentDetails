using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPaymentDetails.Dtos
{
    public class PaymentReadDto
    {
        public int Id { get; set; }

        public string CardOwnerName { get; set; }

        public string CardNumber { get; set; }

        public string ExpirationDate { get; set; }

        public string CVV { get; set; }
    }
}
