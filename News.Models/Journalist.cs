using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using News.Models.Enum;
using System.ComponentModel.DataAnnotations;


namespace News.Models
{
    public  class Journalist
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int InsuranceNumber { get; set; }
        public Role Role { get; set; }
        public string PhoneNumber { get; set; }
        public List<Incident> Incidents { get; set; }
    }
}




