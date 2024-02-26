using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using News.Models.Enum;
using System.ComponentModel.DataAnnotations;


namespace News.Models
{
    public  class Journalist
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        //[Required]
        //public string RegisterTime { get; set; }
        [Required]
        public long InsuranceNumber { get; set; }
        [Required]
        public Role Role { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [ValidateNever]
        public List<Incident> Incidents { get; set; }


    }
}




