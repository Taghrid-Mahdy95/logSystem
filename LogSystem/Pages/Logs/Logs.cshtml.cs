﻿using LogSystemTutorial.DatabaseSpecific;
using LogSystemTutorial.EntityClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogSystemTutorial.Linq;
using LogSystemTutorial.HelperClasses;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Linq;
using System;

namespace LogSystem.Pages.Logs
{
    public class MainModel : PageModel
    {
        [BindProperty] 
        public EntityCollection<EntryEntity> AllEntries{ set; get; }
        
        [BindProperty] 
        public EntityCollection<EntryEntity> TodayEntries { set; get; }
        
        [BindProperty] 
        public EntityCollection<EntryEntity> YesterdayEntries { set; get; }
        
        [BindProperty] 
        public EntityCollection<ProjectEntity> AllProjects { set; get; }
        
        public MainModel()
        {
            TodayEntries = new EntityCollection<EntryEntity>();
            YesterdayEntries = new EntityCollection<EntryEntity>();
        }
        public async void OnGetAsync()
        {
            var loggedUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            using (var adapter = new DataAccessAdapter("Database=LogSystem;Server=localhost;Port=5432;User Id=postgres;Password=1234567890"))
            {
                var metaData = new LinqMetaData(adapter);

                var q = from entries in metaData.Entry
                        where entries.UserId == long.Parse(loggedUserId)
                        select entries;

                AllEntries = await q.ExecuteAsync<EntityCollection<EntryEntity>>();
                AllProjects = await metaData.Project.ExecuteAsync<EntityCollection<ProjectEntity>>();
            }

            foreach (var entry in AllEntries)
            {
                if (entry.Date.Day == DateTime.Now.Day)
                    TodayEntries.Add(entry);
                else if (entry.Date.Day == DateTime.Now.AddDays(-1).Day)
                    YesterdayEntries.Add(entry);
            }
        }
        public RedirectToPageResult OnPostDelete(int id)
        {
            using (var adapter = new DataAccessAdapter("Database=logsSystem;Server=localhost;Port=5432;User Id=postgres;Password=1234567"))
            {
                EntryEntity deletedEntry = new EntryEntity(id);
                adapter.DeleteEntity(deletedEntry);
            }

            return RedirectToPage("Logs");
        }
    }
}