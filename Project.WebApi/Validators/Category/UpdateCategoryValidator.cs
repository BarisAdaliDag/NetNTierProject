using FluentValidation;
using Project.WebApi.Models.RequestModels.Categories;

namespace Project.WebApi.Validators.Category
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryRequestModel>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Geçerli bir ID giriniz");

            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Kategori adı boş olamaz")
                .Length(3, 50).WithMessage("Kategori adı 3-50 karakter olmalı");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz")
                .MaximumLength(200).WithMessage("Açıklama en fazla 200 karakter olabilir");
        }
    }





























}
