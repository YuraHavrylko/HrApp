using System;

namespace HrApp.Models.Search
{
    public class InterviewSearchModel
    {
        public int InterviewId { get; set; }

        public DateTime? InterviewStartDate { get; set; }

        public DateTime? InterviewFinishDate { get; set; }

        public int? Point { get; set; }

        public string Comment { get; set; }

        public string FileResume { get; set; }

        public string FileTest { get; set; }

        public int PersonId { get; set; }
    }
}