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
        public string Title { get; set; }
        [Required]
        public string UrlAddress { get; set; }
        [Required]
        public int Rate { get; set; }
        [Required]
        public DateTime InsertionDate { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
