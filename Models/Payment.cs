using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPaymentDetails.Models
{
    public class Payment
    {
        [Key]
        [Required]
        public int Id { get; set; }

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
