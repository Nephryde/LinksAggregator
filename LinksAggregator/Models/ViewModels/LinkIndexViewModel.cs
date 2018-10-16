using LinksAggregator.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinksAggregator.Models.ViewModels
{
    public class LinkIndexViewModel
    {
        public IEnumerable<ListingLinksViewModel> Links { get; set; }
        public string ApplicationUserId { get; set; }

    }
}
