using News.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models.ModelView
{
    public class UserMV
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int InsuranceNumber { get; set; }
        public Role Role { get; set; }
        public string PhoneNumber { get; set; }
        public Journalist journalist { get; set; }  
        public Admin admin { get; set; }
        public UserMV() { 
            journalist = new Journalist();
            admin = new Admin();
        }
        public Journalist CreateJournalist()
        {
            journalist.FirstName = FirstName;
            journalist.LastName = LastName;
            journalist.InsuranceNumber = InsuranceNumber; 
            journalist.Role = Role.Journalist;
            journalist.PhoneNumber = PhoneNumber;
            return journalist;
        }
        public Admin CreateAdmin()
        {
            admin.FirstName = FirstName;
            admin.LastName = LastName;
            admin.InsuranceNumber = InsuranceNumber;
            admin.Role = Role.Journalist;
            admin.PhoneNumber = PhoneNumber;
            return admin;
        }
    }
}
