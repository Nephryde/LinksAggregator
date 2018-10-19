using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinksAggregator.Models
{
    public class LinkVote
    {
        public int Id { get; set; }
        public int LinkId { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
