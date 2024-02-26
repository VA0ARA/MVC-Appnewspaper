using News.Models.Enum;
using System.ComponentModel.DataAnnotations;
namespace News.Models
{
    public  class Admin
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long InsuranceNumber { get; set; }
        public Role Role { get; set; }
        public string PhoneNumber { get; set; }

    }
}




