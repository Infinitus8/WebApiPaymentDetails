using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiPaymentDetails.Data;
using WebApiPaymentDetails.Dtos;
using WebApiPaymentDetails.Models;

namespace WebApiPaymentDetails.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsRepo _repository;

        private readonly IMapper _mapper;

        public PaymentsController(IPaymentsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

         //GET api/payments
         [HttpGet]
         public ActionResult<IEnumerable<PaymentReadDto>> GetPayments()
        {
            var paymentItems = _repository.GetPayments();

            return Ok(_mapper.Map<IEnumerable<PaymentReadDto>>(paymentItems));
        }

        [HttpGet("{id}", Name="GetPaymentById")]
        public ActionResult<PaymentReadDto> GetPaymentById(int id)
        {
            var paymentItem = _repository.GetPaymentById(id);
            if (paymentItem != null)
            {
                return Ok(_mapper.Map<PaymentReadDto>(paymentItem));
            }

            return NotFound();
        }

        //POST api/payments
        [HttpPost]
        public ActionResult <PaymentAddDto> AddCommand(PaymentAddDto paymentAddDto)
        {
            var paymentModel = _mapper.Map<Payment>(paymentAddDto);
            _repository.AddPayment(paymentModel);
            _repository.SaveChanges();

            var paymentReadDto = _mapper.Map<PaymentReadDto>(paymentModel);

            return CreatedAtRoute(nameof(GetPaymentById), new { Id = paymentReadDto.Id }, paymentReadDto);
        }

        //PUT api/payments/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePayment(int id, PaymentUpdateDto paymentUpdateDto)
        {
            var paymentModelFromRepo = _repository.GetPaymentById(id);
            if (paymentModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(paymentUpdateDto, paymentModelFromRepo);

            _repository.UpdatePayment(paymentModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/payments/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialPaymentUpdate(int id, JsonPatchDocument<PaymentUpdateDto> patchDoc)
        {
            var paymentModelFromRepo = _repository.GetPaymentById(id);
            if (paymentModelFromRepo == null)
            {
                return NotFound();
            }

            var paymentToPatch = _mapper.Map<PaymentUpdateDto>(paymentModelFromRepo);
            patchDoc.ApplyTo(paymentToPatch, ModelState);

            if (!TryValidateModel(paymentToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(paymentToPatch, paymentModelFromRepo);

            _repository.UpdatePayment(paymentModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/payments/{id]
        [HttpDelete("{id}")]
        public ActionResult DeletePayment(int id)
        {
            var paymentModelFromRepo = _repository.GetPaymentById(id);
            if (paymentModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeletePayment(paymentModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
