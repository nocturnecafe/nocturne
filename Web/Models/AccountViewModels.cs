using System.ComponentModel.DataAnnotations;
using Web.Models;

namespace Web.Models
{

    public class LoginViewModel: ViewModelBase
    {
        [Required]
        [Display(Name = "Reg. code")]
        public string RegCode { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
    
}
