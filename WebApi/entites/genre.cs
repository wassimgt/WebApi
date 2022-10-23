using System.ComponentModel.DataAnnotations;
using WebApi.validation;

namespace WebApi.entites
{
    public class genre
    {
      

        public int Id { get; set; }
        [Required(ErrorMessage ="the field with  {0} is required")]
        [StringLength(10)]
        [FirstLetterUppercase]
   
        public string Name { get; set; }

     
    }
}
