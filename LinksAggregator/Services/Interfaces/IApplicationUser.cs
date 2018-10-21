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
        string GetUserNickname(string id);
        string GetUserEmail(string id);
        Task<IdentityResult> SetUserNickname(ApplicationUser user, string newNickname);
    }
}
