﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogSystemTutorial.EntityClasses;
using System.ComponentModel.DataAnnotations;
using LogSystemTutorial.DatabaseSpecific;
using LogSystemTutorial.HelperClasses;
using LogSystemTutorial.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace LogSystem.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Required,MinLength(4)]
        public string Name { set; get; }

        [BindProperty]
        [Required, DataType(DataType.EmailAddress),RegularExpression(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$")]
        public string Email { set; get; }
        
        [BindProperty]
        [Required,DataType(DataType.Password),StringLength(10,MinimumLength = 4)]
        public string Password { set; get; }
        public UserEntity NewUser { set; get; }
        
        [BindProperty] 
        public bool UserExistCheck { set; get; }

        public IndexModel()
        {
            NewUser = new UserEntity();
        }

        public void OnGet()
        {
            UserExistCheck = true;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            NewUser.Name = Name;
            NewUser.Email = Email;
            NewUser.Password = Password;

            using (var adapter = new DataAccessAdapter("Database=LogSystem;Server=localhost;Port=5432;User Id=postgres;Password=1234567890"))
            {

               var metaData = new LinqMetaData(adapter);
                var q = from user in metaData.User
                        where user.Email == Email
                        select user;

                EntityCollection<UserEntity> userCheck = q.Execute<EntityCollection<UserEntity>>();
               
                if(userCheck.Count != 0)
                {
                    UserExistCheck = false;
                    return Page();
                }
                else
                {
                    await adapter.SaveEntityAsync(NewUser);
                    return RedirectToPage("Logs/Main");
                }
            }
        }
    }
}