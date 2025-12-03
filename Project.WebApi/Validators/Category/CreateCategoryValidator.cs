using FluentValidation;
using Project.WebApi.Models.RequestModels.Categories;

namespace Project.WebApi.Validators.Category
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryRequestModel>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Kategori adı boş olamaz")
                .Length(3, 50).WithMessage("Kategori adı 3-50 karakter olmalı");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz")
                .MaximumLength(200).WithMessage("Açıklama en fazla 200 karakter olabilir");
        }
    }





























}
