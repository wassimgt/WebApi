using System.ComponentModel.DataAnnotations;

namespace WebApi.validation
{
    public class FirstLetterUppercase : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var firstletter = value.ToString()[0].ToString();
            if(firstletter != firstletter.ToUpper())
            {
                return new ValidationResult("first letter to be uppercase");
            }
            return ValidationResult.Success;    
            //return base.IsValid(value, validationContext);
        }

    }
}
