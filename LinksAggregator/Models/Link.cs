using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinksAggregator.Models
{
    public class Link
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name ="Tytuł")]
        public string Title { get; set; }
        [Required]
        public string UrlAddress { get; set; }
        [Required]
        public int Rate { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime InsertionDate { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Opis może składać się maksymalnie ze 100 znaków.")]
        public string Description { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
