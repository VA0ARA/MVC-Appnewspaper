using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace News.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [ValidateNever]
        public List<Incident>Incidents { get; set; }
    }
}
