using LinksAggregator.Data;
using LinksAggregator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinksAggregator.Services
{
    public class LinkService : ILink
    {
        private ApplicationDbContext _context;

        public LinkService(ApplicationDbContext context) => _context = context;

        public async Task Add(Link newLink)
        {
            await _context.AddAsync(newLink);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Link>> GetAll()
        {
            return await _context.Links.ToListAsync();
        }

        public async Task<Link> GetById(int id)
        {
            return await _context.Links
                .FirstOrDefaultAsync(link => link.Id == id);
        }

        public async Task Delete(int id)
        {
            Link link = await GetById(id);
            if(link != null)
            {
                _context.Links.Remove(link);
                await _context.SaveChangesAsync();
            }           
        }

        public async Task AddVote(int id)
        {
            Link link = await GetById(id);
            int rate = link.Rate;
            rate++;
            link.Rate = rate;
            await _context.SaveChangesAsync();
        }

        public string GetUserId(int id)
        {
            return _context.Links
                .FirstOrDefault(link => link.Id == id)
                .ApplicationUserId;
        }
     
    }
}
