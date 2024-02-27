using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace News.Models.ViewModel
{
    public  class IncidentVM
    {
        public Incident incident { get; set; }
       // [ValidateNever]
/*        public IEnumerable<SelectListItem> CategoryList{ get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> JournalistList { get; set; }*/
    }
}
