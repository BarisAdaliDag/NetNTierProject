using FluentValidation;
using Project.WebApi.Models.RequestModels.AppUserProfile;

namespace Project.WebApi.Validators.AppUserProfile
{
    public class UpdateAppUserProfileValidator : AbstractValidator<UpdateAppUserProfileRequestModel>
    {
        public UpdateAppUserProfileValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Geçerli bir ID giriniz");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad boş olamaz")
                .Length(2, 50).WithMessage("Ad 2-50 karakter olmalı");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad boş olamaz")
                .Length(2, 50).WithMessage("Soyad 2-50 karakter olmalı");
        }
    }
}