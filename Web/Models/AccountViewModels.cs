using System.ComponentModel.DataAnnotations;

namespace Web.Models
{

    public class LoginViewModel
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
    }
    
}
