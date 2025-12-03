using FluentValidation;
using Project.WebApi.Models.RequestModels.Product;

namespace Project.WebApi.Validators.Product
{
    public class CreateProductValidator : AbstractValidator<CreateProductRequestModel>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adı boş olamaz")
                .Length(2, 100).WithMessage("Ürün adı 2-100 karakter olmalı");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalı");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Geçerli bir kategori seçiniz")
                .When(x => x.CategoryId.HasValue);
        }
    }
}