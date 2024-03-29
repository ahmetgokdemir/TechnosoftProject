﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Context;
using Project.ENTITIES.Identity_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using Technosoft_Project; referans verilmeli ki using'i kullanılabilsin

namespace Project.DAL.Strategy
{
    public static class SeedRoles
    {
        public static async Task Seed(IServiceProvider serviceProvider)
        {
            using (UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>())
            {

                List<AppUser> userlist = new List<AppUser>()
                {
                    new AppUser()
                    { 
                        UserName="ahmetgokdemir", 
                        PasswordHash= "ctz*9913", 
                        Email = "ahmetgokdemirtc@gmail.com", 
                        EmailConfirmed = true /*, Gender = ENTITIES.Enums.Gender.Bay*/, 
                        Picture = "/UserPicture/user.webp", 
                        City="Istanbul", 
                        IsConfirmedAccount= ENTITIES.Enums.IsConfirmedAccount.Aktif 
                    }
                    // new AppUser(){UserName ="David@hotmial.com", Password="Abc12345!"}
                };

                /*
                var userlistv2 = new AppUser()
                {
                    UserName = "ahmetgokdemir",
                    PasswordHash = "ctz*9913",
                    Email = "ahmetgokdemirtc@gmail.com",
                    EmailConfirmed = true,
                    Gender = 1,
                    Picture = "/UserPicture/user.webp"

                };
                */

                foreach (AppUser user in userlist)
                {
                    if (!_userManager.Users.Any(r => r.Email == user.Email))
                    {
                        //var newuser = new IdentityUser { UserName = user.UserName, Email = user.UserName };
                        IdentityResult result = await _userManager.CreateAsync(user, user.PasswordHash);
                        bool b = result.Succeeded;
                        await _userManager.AddToRoleAsync(user, "Admin");
                         
                    }                  


                }
            }


            using (RoleManager<AppRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>())
            {
                List<AppRole> rolelist = new List<AppRole>()
                    {
                        new AppRole(){ Name="Admin" },
                        new AppRole(){ Name="Manager" },
                        new AppRole(){ Name="Editor" },
                        new AppRole(){ Name="Member" }


                    };

                foreach (AppRole role in rolelist)
                {
                    if (!_roleManager.Roles.Any(r => r.Name == role.Name))
                    {
                        IdentityResult result = _roleManager.CreateAsync(role).Result;
                    }
                }
            }


        }

        /*
        public static int Seedv2()
        {
            return 5;
        }
        */


        //public static async Task Seedv3(IServiceProvider serviceProvider)
        //{

        //}

    }
}

