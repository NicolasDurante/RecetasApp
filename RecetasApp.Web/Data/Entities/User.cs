﻿namespace RecetasApp.Web.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }


    }
}
