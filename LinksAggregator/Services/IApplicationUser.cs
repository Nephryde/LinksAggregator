using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinksAggregator.Models;
using Microsoft.AspNetCore.Identity;

namespace LinksAggregator.Services
{
    public interface IApplicationUser
    {
        Task<IEnumerable<ApplicationUser>> GetAll();
        Task<ApplicationUser> GetById(string id);
        string GetUserNickname(string id);
        Task<IdentityResult> SetUserNickname(ApplicationUser user, string newNickname);
    }
}
