using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinksAggregator.Models.ViewModels
{
    public class ListingLinksViewModel
    {
        public int Id { get; set; }
        public string UrlAddress { get; set; }
        public string Title { get; set; }
        public int Rate { get; set; }
        public DateTime InsertionDate { get; set; }
        public string Description { get; set; }
        public string ApplicationUserId { get; set; }
        public string ApplicationUserNickname { get; set; }
        public double SubtractedDates { get; set; }
        public string ApplicationUserEmail { get; set; }

    }
}
