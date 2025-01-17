﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogSystemTutorial.EntityClasses;
using LogSystemTutorial.DatabaseSpecific;
using LogSystemTutorial.HelperClasses;
using LogSystemTutorial.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace LogSystem.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty] 
        public string Email { get; set; }
        
        [BindProperty] 
        public string Password { get; set; }
        
        [BindProperty] 
        public bool UserNotFound { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            using (var adapter = new DataAccessAdapter("Database=LogSystem;Server=localhost;Port=5432;User Id=postgres;Password=1234567890"))
            {
                var metadata = new LinqMetaData(adapter);

                var q = from user in metadata.User
                        where user.Email == Email && user.Password == Password
                        select user;
                var usercheck = q.Execute<EntityCollection<UserEntity>>();
                
                if (usercheck.Count != 0)
                {
                    var claims = new List<Claim>
                    {
                        new Claim (ClaimTypes.NameIdentifier,usercheck[0].Id.ToString()),
                        new Claim (ClaimTypes.Name, usercheck[0].Name)
                    };
                
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var prinicipal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, prinicipal);

                    return RedirectToPage("/Logs/Logs");
                }
                else
                {
                    UserNotFound = true;
                    
                    return Page();
                }
            }
        }
    }
}