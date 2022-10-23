using System.ComponentModel.DataAnnotations;
using WebApi.validation;

namespace WebApi.DTO
{
    public class genrecreateDTO
    {
        [Required(ErrorMessage = "the field with  {0} is required")]
        [StringLength(10)]
        [FirstLetterUppercase]

        public string Name { get; set; }
    }
}
