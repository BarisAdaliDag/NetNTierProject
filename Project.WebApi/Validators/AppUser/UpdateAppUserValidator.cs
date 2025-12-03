using FluentValidation;
using Project.WebApi.Models.RequestModels.AppUser;

namespace Project.WebApi.Validators.AppUser
{
    public class UpdateAppUserValidator : AbstractValidator<UpdateAppUserRequestModel>
    {
        public UpdateAppUserValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Geçerli bir ID giriniz");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı boş olamaz")
                .Length(3, 50).WithMessage("Kullanıcı adı 3-50 karakter olmalı");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş olamaz")
                .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalı");
        }
    }
}