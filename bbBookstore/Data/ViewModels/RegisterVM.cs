using System.ComponentModel.DataAnnotations;

namespace bbBookstore.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please enter your full name!")]
        public string FullName { get; set; }

        [Display(Name ="Email Address")]
        [Required(ErrorMessage ="Please enter your email address!")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please enter your password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please confirm your password!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="The passwords do not match!")]
        public string ConfirmPassword { get; set; }
    }
}
