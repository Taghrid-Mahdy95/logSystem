﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogSystemTutorial.DatabaseSpecific;
using LogSystemTutorial.EntityClasses;
using LogSystemTutorial.HelperClasses;
using LogSystemTutorial.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;

namespace LogSystem.Pages.Logs
{
    public class NewEntryModel : PageModel
    {
        [BindProperty] 
        public EntryEntity NewEntryEntity { set; get; }
        
        [BindProperty] 
        public EntityCollection<ProjectEntity> AllProjects { set; get; }
        
        [BindProperty] 
        public  string SelectedProjectId { set; get; }
        
        [BindProperty] 
        public List<SelectListItem> AllProjectsOptions { set; get; }

        public NewEntryModel()
        {
            NewEntryEntity = new EntryEntity();
            AllProjectsOptions = new List<SelectListItem>();
        }

        public async void OnGetAsync()
        {
            using (var adapter = new DataAccessAdapter("Database=LogSystem;Server=localhost;Port=5432;User Id=postgres;Password=1234567890"))
            {
                var metaData = new LinqMetaData(adapter);

                var q = from project in metaData.Project
                        where project.Status == true
                        select project;

                AllProjects = await metaData.Project.ExecuteAsync<EntityCollection<ProjectEntity>>();
            }

            AllProjectsOptions = AllProjects.Select(x => new SelectListItem { Text = x.Name , Value= x.Id.ToString()}).ToList();

        }
        public async Task<IActionResult> OnPostAsync()
        {
            var LoggedUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            NewEntryEntity.Date = DateTime.Now;
            NewEntryEntity.UserId = long.Parse(LoggedUserId);

            if(SelectedProjectId != null)
                NewEntryEntity.ProjectId = long.Parse(SelectedProjectId);

            using (var adapter = new DataAccessAdapter("Database=logsSystem;Server=localhost;Port=5432;User Id=postgres;Password=1234567"))
            {
                await adapter.SaveEntityAsync(NewEntryEntity,true);
            }

            return RedirectToPage("Logs");
        }
    }
}