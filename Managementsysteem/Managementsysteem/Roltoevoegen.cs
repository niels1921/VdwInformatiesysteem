using Managementsysteem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managementsysteem
{
    public class Roltoevoegen
    {
        private async Task RolAsync(IServiceProvider serviceProvider , string User, string Role)
        {
            var usermanager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var Roleuser = new ApplicationUser
            {
                UserName = User,
                Email = User,
            };

            await usermanager.AddToRoleAsync(Roleuser, Role);
        }
    }
}
