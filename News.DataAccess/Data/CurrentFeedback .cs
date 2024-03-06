using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataAccess.Data
{
    public static class CurrentFeedback
    {
        public static FeedBack CurentFeedbackobj= new FeedBack();
        public static void  FirstInit()
        {
            CurentFeedbackobj.Comment = "";
            CurentFeedbackobj.DisLike = 0;
            CurentFeedbackobj.Like = 0;
            CurentFeedbackobj.View= 0;
            CurentFeedbackobj.IncidentId = 0;   
        }
    }
}
