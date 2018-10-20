using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinksAggregator.Models.AccountViewModels
{
    public class LoginWithRecoveryCodeViewModel
    {
            [Required(ErrorMessage = "To pole jest wymagane.")]
            [DataType(DataType.Text)]
            [Display(Name = "Kod Recovery")]
            public string RecoveryCode { get; set; }
    }
}
