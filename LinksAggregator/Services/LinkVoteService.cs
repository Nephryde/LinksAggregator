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

        public async Task<IEnumerable<LinkVote>> GetAll()
        {
            return await _context.LinkVotes.ToListAsync();
        }

        public async Task Add(LinkVote linkVote)
        {
            await _context.LinkVotes.AddAsync(linkVote);
            await _context.SaveChangesAsync();
        }

        public int CountVotes(int linkId, string userId)
        {
            return _context.LinkVotes.AsNoTracking()
                .Where(x => x.LinkId == linkId && x.ApplicationUserId == userId)
                .ToList()
                .Count;
        }

        public bool VoteCheck(int linkId, string applicationUserId)
        {
            foreach(LinkVote link in _context.LinkVotes)
            {
                if(link.LinkId == linkId)
                {
                    if (link.ApplicationUserId == applicationUserId)
                        return true;
                    else
                        return false;
                }
            }

            return false;
        }

        public int GetLinkId(int id)
        {
            throw new NotImplementedException();
        }

        public string GetUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
