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
        public ILinkVote _linkVotes;
        public LinkController(
            ILink links, 
            IApplicationUser users, 
            ILinkVote linkVotes,
            UserManager<ApplicationUser> userManager)
        {
            _links = links;
            _users = users;
            _linkVotes = linkVotes;
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
                    ApplicationUserId = _links.GetUserId(result.Id),
                    SubtractedDates = (DateTime.Now - result.InsertionDate).TotalDays,
                    ApplicationUserEmail = _users.GetUserEmail(_links.GetUserId(result.Id))
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
            bool hasVoted = _linkVotes.VoteCheck(id, _userManager.GetUserId(User));

            if (!hasVoted)
                await _links.AddVote(id);
            else
            {
                TempData["alert"] = "alert";

                return RedirectToAction(nameof(Index));
            }

            LinkVote linkVote = new LinkVote
            {
                LinkId = id,
                ApplicationUserId = _userManager.GetUserId(User)
            };

            await _linkVotes.Add(linkVote);

            return RedirectToAction(nameof(Index));
        }
    }
}