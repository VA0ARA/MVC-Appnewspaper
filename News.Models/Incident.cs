using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace News.Models
{
    public  class Incident

    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description{ get; set; }
        [Required]
        public string Overview { get; set; }
        [Required]
        public bool PermitToPublish { get; set; }
        [Required]
        [Display(Name =" Number Of View ")]
        [Range(1,1000)]
        public int NumberOfView { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
        [ForeignKey("JournalistId")]
        public int JournalistId { get; set; }
        [ValidateNever]
        public Journalist Journalist { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }

    }
}
