using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinksAggregator.Models;

namespace LinksAggregator.Services
{
    public interface ILinkVote
    {
        Task Add(LinkVote linkVote);
        bool VoteCheck(int linkId, string applicationUserId);
    }
}
