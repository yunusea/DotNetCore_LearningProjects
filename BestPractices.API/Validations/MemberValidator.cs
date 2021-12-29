using BestPractices.API.Models;
using FluentValidation;

namespace BestPractices.API.Validations
{
    //Implementation of AbstractValidatorClass for Validation Method Running 
    public class MemberValidator : AbstractValidator<MemberDVO>
    {
        //Creating validation rules in contractor
        public MemberValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("İsim-Soyisim Boş Olamaz !");    
            RuleFor(x => x.Id).LessThan(100).WithMessage("Id 100'den Büyük Olamaz !");
        }
    }
}
