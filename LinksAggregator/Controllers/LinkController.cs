using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinksAggregator.Models;
using LinksAggregator.Models.ViewModels;
using LinksAggregator.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LinksAggregator.Controllers
{
    public class LinkController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ILink _links;
        public IApplicationUser _users;
        public LinkController(ILink links, IApplicationUser users, UserManager<ApplicationUser> userManager)
        {
            _links = links;
            _users = users;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var linkModels = await _links.GetAll();

            var listingResult = linkModels
                .Select(result => new ListingLinksViewModel
                {
                    Id = result.Id,
                    UrlAddress = result.UrlAddress,
                    Title = result.Title,
                    Rate = result.Rate,
                    InsertionDate = result.InsertionDate,
                    ApplicationUserNickname = _users.GetUserNickname(_links.GetUserId(result.Id)),
                    Description = result.Description,
                    ApplicationUserId = _links.GetUserId(result.Id)
                });


            var model = new LinkIndexViewModel()
            {
                Links = listingResult.OrderByDescending(r => r.Rate),
                ApplicationUserId = _userManager.GetUserId(User)
            };
            
            
            return View(model);
        }

        public async Task<IActionResult> AddVote(int id)
        {
            //var user = await _userManager.GetUserAsync(User);
            //var link = await _links.GetById(id);

            //if(user.Id != link.ApplicationUserId)
            //{
            //    throw new Exception("Errorror");
            //}
            //else
                await _links.AddVote(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<bool> AddVoteAuthenticate(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var link = await _links.GetById(id);

            if (user.Id != link.ApplicationUserId)
            {
                return true;
            }
            else
                return false;

        }


    }
}