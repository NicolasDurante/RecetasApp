namespace RecetasApp.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterNewUserViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }


        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        //compara Confirm con Password
        [Required]
        [Compare("Password")]
        public string Confirm { get; set; }
    }
}
