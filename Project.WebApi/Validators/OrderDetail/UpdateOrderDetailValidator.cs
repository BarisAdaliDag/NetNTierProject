using FluentValidation;
using Project.WebApi.Models.RequestModels.OrderDetail;

namespace Project.WebApi.Validators.OrderDetail
{
    public class UpdateOrderDetailValidator : AbstractValidator<UpdateOrderDetailRequestModel>
    {
        public UpdateOrderDetailValidator()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("Geçerli bir sipariş ID'si giriniz");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Geçerli bir ürün ID'si giriniz");
        }
    }
}