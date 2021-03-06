﻿using LinksAggregator.Data;
using LinksAggregator.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinksAggregator.Services
{
    public class ApplicationUserService : IApplicationUser
    {
        private ApplicationDbContext _context;

        public ApplicationUserService(ApplicationDbContext context) => _context = context;

        public string GetUserNickname(string id)
        {
            return _context.ApplicationUsers
                .FirstOrDefault(user => user.Id == id)
                .Nickname;
        }

        public string GetUserEmail(string id)
        {
            return _context.ApplicationUsers
                .FirstOrDefault(user => user.Id == id)
                .Email;
        }

        public async Task<IdentityResult> SetUserNickname(ApplicationUser user, string newNickname)
        {
            user.Nickname = newNickname;
            await _context.SaveChangesAsync();

            return IdentityResult.Success;
        }        
    }
}
