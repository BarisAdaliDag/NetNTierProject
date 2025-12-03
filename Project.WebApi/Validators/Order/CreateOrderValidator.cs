using FluentValidation;
using Project.WebApi.Models.RequestModels.Order;

namespace Project.WebApi.Validators.Order
{
    // ==========================================
    // ORDER VALIDATORS
    // ==========================================
    public class CreateOrderValidator : AbstractValidator<CreateOrderRequestModel>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.ShippingAddress)
                .NotEmpty().WithMessage("Teslimat adresi boş olamaz")
                .MinimumLength(10).WithMessage("Teslimat adresi en az 10 karakter olmalı");

            RuleFor(x => x.AppUserId)
                .GreaterThan(0).WithMessage("Geçerli bir kullanıcı seçiniz")
                .When(x => x.AppUserId.HasValue);
        }
    }
}