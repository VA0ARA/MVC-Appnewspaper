using News.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models.ModelView
{
    public  class LoginDtos
    {
        public string PhoneNumber { get; set; }
        public int InsuranceNumber { get; set; }
        public Journalist journalist { get; set; }  
        public Admin admin { get; set; }
        public LoginDtos() {
        
            journalist = new Journalist();
            admin = new Admin();
        }

    }
}
