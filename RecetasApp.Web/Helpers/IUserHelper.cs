﻿namespace RecetasApp.Web.Helpers
{
    using Microsoft.AspNetCore.Identity;
    using RecetasApp.Web.Data.Entities;
    using System.Threading.Tasks;
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);
    }

}