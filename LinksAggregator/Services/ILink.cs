using LinksAggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinksAggregator.Services
{
    public interface ILink
    {
        Task<IEnumerable<Link>> GetAll();
        Task<Link> GetById(int id);
        Task Add(Link newLink);
        Task Delete(int id);
        string GetTitle(int id);
        string GetUrlAddress(int id);
        int GetRate(int id);
        Task AddVote(int id);
        string GetUserId(int id);

        Task<ApplicationUser> GetUser(int id);

        Task SaveChanges();
    }
}
