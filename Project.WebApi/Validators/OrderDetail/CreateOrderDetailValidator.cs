using FluentValidation;
using Project.WebApi.Models.RequestModels.OrderDetail;

namespace Project.WebApi.Validators.OrderDetail
{
    // ==========================================
    // ORDERDETAIL VALIDATORS
    // ==========================================
    public class CreateOrderDetailValidator : AbstractValidator<CreateOrderDetailRequestModel>
    {
        public CreateOrderDetailValidator()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("Geçerli bir sipariş ID'si giriniz");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Geçerli bir ürün ID'si giriniz");
        }
    }
}