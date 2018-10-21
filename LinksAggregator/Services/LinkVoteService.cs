using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinksAggregator.Data;
using LinksAggregator.Models;
using Microsoft.EntityFrameworkCore;

namespace LinksAggregator.Services
{
    public class LinkVoteService : ILinkVote
    {
        private ApplicationDbContext _context;

        public LinkVoteService(ApplicationDbContext context) => _context = context;

        public async Task Add(LinkVote linkVote)
        {
            await _context.LinkVotes.AddAsync(linkVote);
            await _context.SaveChangesAsync();
        }

        public bool VoteCheck(int linkId, string applicationUserId)
        {
            return _context.LinkVotes.AsNoTracking()
                .Where(link => link.LinkId == linkId && link.ApplicationUserId == applicationUserId)
                    .Any();
        }
    }
}
