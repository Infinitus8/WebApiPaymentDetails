using AutoMapper;
using WebApiPaymentDetails.Dtos;
using WebApiPaymentDetails.Models;

namespace WebApiPaymentDetails.Profiles
{
    public class PaymentsProfile : Profile
    {
        public PaymentsProfile()
        {
            //Source -> Target
            CreateMap<Payment, PaymentReadDto>();
            CreateMap<PaymentAddDto, Payment>();
            CreateMap<PaymentUpdateDto, Payment>();
            CreateMap<Payment, PaymentUpdateDto>();
        }
    }
}
