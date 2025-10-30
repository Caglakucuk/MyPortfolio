using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class ProjectValidator : AbstractValidator<Projects>
{
    private const string UrlRegex = 
        @"^(http|https)://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$";
    public ProjectValidator()
    {
        RuleFor(x => x.title).NotEmpty().WithMessage("Proje Adı Boş Geçilemez");
        RuleFor(x => x.description).NotEmpty().WithMessage("Açıklama Alanı Boş Geçilemez");
        RuleFor(x => x.technologies).NotEmpty().WithMessage("Kullanılan Teknolojiler Alanı Boş Geçilemez");
        RuleFor(x => x.githubLink).NotEmpty().WithMessage("Github Linki Boş Geçilemez");
        RuleFor(x => x.githubLink).Matches(UrlRegex).WithMessage("Lütfen geçerli bir URL formatında link girin.");
    }
    
}