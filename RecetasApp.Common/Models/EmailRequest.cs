namespace RecetasApp.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    public class EmailRequest
    {
        [Required]
        [EmailAddress]
        public  string Email   { get; set; }
    }
}
