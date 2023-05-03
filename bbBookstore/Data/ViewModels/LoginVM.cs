using System.ComponentModel.DataAnnotations;

namespace bbBookstore.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="Email Address")]
        [Required(ErrorMessage ="Please enter your email address!")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please enter your password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
