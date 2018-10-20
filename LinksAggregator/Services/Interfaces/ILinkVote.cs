using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinksAggregator.Models;

namespace LinksAggregator.Services
{
    public interface ILinkVote
    {
        Task<IEnumerable<LinkVote>> GetAll();
        Task Add(LinkVote linkVote);
        string GetUserId(int id);
        int GetLinkId(int id);
        int CountVotes(int linkId, string userId);
        bool VoteCheck(int linkId, string applicationUserId);
    }
}
