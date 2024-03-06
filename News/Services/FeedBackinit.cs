using News.Models;

namespace News.Services
{
    public class FeedBackinit
    {
        public FeedBack FeedBack { get; set; }

        public void AddLike()
        {
            DataAccess.Data.CurrentFeedback.CurentFeedbackobj.Like++;
            DataAccess.Data.CurrentFeedback.CurentFeedbackobj.View++;
        }
        public void AddDislike()
        {
            DataAccess.Data.CurrentFeedback.CurentFeedbackobj.DisLike++;
            DataAccess.Data.CurrentFeedback.CurentFeedbackobj.View++;
        }
    }
}
