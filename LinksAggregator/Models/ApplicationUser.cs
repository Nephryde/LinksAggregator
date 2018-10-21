using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LinksAggregator.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(20, ErrorMessage = "Pseudonim może składać się maksymalnie z 500 znaków.")]
        public string Nickname { get; set; }
        public virtual ICollection<Link> Links { get; set; }
    }
}
