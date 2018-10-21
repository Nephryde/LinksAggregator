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

        [Required(ErrorMessage = "To pole jest wymagane.")]
        [StringLength(50, ErrorMessage = "Tytuł może składać się maksymalnie z 50 znaków.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane.")]
        [StringLength(200, ErrorMessage = "Opis może składać się maksymalnie z 200 znaków.")]
        public string UrlAddress { get; set; }

        [Required]
        public int Rate { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime InsertionDate { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane.")]
        [StringLength(500, ErrorMessage = "Opis może składać się maksymalnie z 500 znaków.")]
        public string Description { get; set; }
        
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
