using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models
{
    public  class FeedBack
    {
        public int Id{ get; set; }
        [MaxLength(300)]
        public string Comment { get; set; }
        public int View { get; set; }
        public int Like { get; set; }
        public int DisLike { get; set; }
        public int  IncidentId { get; set; }
        public Incident incident { get; set; }
    }
}
