using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace News.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "کوتاه تر بنویسید")]
        [DisplayName("نام گروه خبری")]
        public string Name { get; set; }
        [ValidateNever]
        public List<Incident>Incidents { get; set; }
    }
}
