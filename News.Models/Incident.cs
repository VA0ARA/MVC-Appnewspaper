using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace News.Models
{
    public  class Incident

    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description{ get; set; }
        public string Overview { get; set; }
        public bool PermitToPublish { get; set; }
/*        [Display(Name =" Number Of View ")]
        [Range(1,1000)]*/
        public int NumberOfView { get; set; }
        public int CategoryId { get; set; }
        //[ValidateNever]
        public Category Category { get; set; }
        public int JournalistId { get; set; }
       // [ValidateNever]
        public Journalist Journalist { get; set; }
       // [ValidateNever]
        public string? ImageUrl { get; set; }

    }
}
