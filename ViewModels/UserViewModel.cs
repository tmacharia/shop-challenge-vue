using System.ComponentModel.DataAnnotations;

namespace Shop.Web.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must have atleast 6 characters")]
        public string Password { get; set; }
    }
}