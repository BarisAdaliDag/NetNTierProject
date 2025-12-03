using FluentValidation;
using Project.WebApi.Models.RequestModels.AppUserProfile;

namespace Project.WebApi.Validators.AppUserProfile
{
    // ==========================================
    // APPUSERPROFILE VALIDATORS
    // ==========================================
    public class CreateAppUserProfileValidator : AbstractValidator<CreateAppUserProfileRequestModel>
    {
        public CreateAppUserProfileValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçerli bir AppUser ID'si giriniz");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad boş olamaz")
                .Length(2, 50).WithMessage("Ad 2-50 karakter olmalı");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad boş olamaz")
                .Length(2, 50).WithMessage("Soyad 2-50 karakter olmalı");
        }
    }
}