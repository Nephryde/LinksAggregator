using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinksAggregator.Models.ViewModels.ManageViewModels
{
    public class AddingNewLinkViewModel
    {      
        public Link Link { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane.")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane.")]
        [Display(Name = "Adres URL")]
        public string UrlAddress { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane.")]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        public string ApplicationUserId { get; set; }
        public DateTime TodayDate { get; set; }
    }
}
