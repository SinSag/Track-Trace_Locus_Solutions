//libraries / nuget - packages / directories
using System.ComponentModel.DataAnnotations;

namespace locustrace.Shared
{
    //Class for UserLogin
    public class UserLogin
    {
        //UserLogin members
        //creates a required attribute for the username input field
        [Required(ErrorMessage = "Please enter username")]
        public string Username { get; set; }

        //creates a required attribute for the password input field
        [Required(ErrorMessage = "Please enter passowrd")]
        public string Password { get; set; }
    }
}
