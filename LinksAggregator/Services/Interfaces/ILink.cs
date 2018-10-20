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
        Task<IEnumerable<Link>> GetUserLinks(string id);
        Task<Link> GetById(int id);
        Task Add(Link newLink);
        Task Delete(int id);
        Task AddVote(int id);
        string GetUserId(int id);
    }
}
