using FluentValidation;
using Project.WebApi.Models.RequestModels.Order;

namespace Project.WebApi.Validators.Order
{
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderRequestModel>
    {
        public UpdateOrderValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Geçerli bir ID giriniz");

            RuleFor(x => x.ShippingAddress)
                .NotEmpty().WithMessage("Teslimat adresi boş olamaz")
                .MinimumLength(10).WithMessage("Teslimat adresi en az 10 karakter olmalı");

            RuleFor(x => x.AppUserId)
                .GreaterThan(0).WithMessage("Geçerli bir kullanıcı seçiniz")
                .When(x => x.AppUserId.HasValue);
        }
    }
}