using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feedby.Models
{
    public class Review
    {
        public Review()
        {
            this.Feedbacks = new List<Feedback>();
        }

        public string WeekYear { get; set; }

        public List<Feedback> Feedbacks { get; set; }

    }
}
