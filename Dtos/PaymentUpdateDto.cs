using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiPaymentDetails.Dtos
{
    public class PaymentUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string CardOwnerName { get; set; }

        [Required]
        [MaxLength(16)]
        public string CardNumber { get; set; }

        [Required]
        [MaxLength(5)]
        public string ExpirationDate { get; set; }

        [Required]
        [MaxLength(3)]
        public string CVV { get; set; }
    }
}
