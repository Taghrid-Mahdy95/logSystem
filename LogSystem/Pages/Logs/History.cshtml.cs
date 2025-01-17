﻿using LogSystemTutorial.DatabaseSpecific;
using LogSystemTutorial.EntityClasses;
using LogSystemTutorial.HelperClasses;
using LogSystemTutorial.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Linq;


namespace LogSystem.Pages.Logs
{
    public class HistoryModel : PageModel
    {
        [BindProperty] 
        public EntityCollection<EntryEntity> Entries { set; get; }
        
        [BindProperty] 
        public EntityCollection<ProjectEntity> AllProjects { set; get; }
        
        [BindProperty] 
        public EntityCollection<UserEntity> AllUsers { set; get; }

        public async void OnGetAsync()
        {
            using (var adapter = new DataAccessAdapter("Database=LogSystem;Server=localhost;Port=5432;User Id=postgres;Password=1234567890"))
            {
                var metaData = new LinqMetaData(adapter);

                AllProjects = metaData.Project.Execute<EntityCollection<ProjectEntity>>();
                AllUsers = metaData.User.Execute<EntityCollection<UserEntity>>();

                var q = from entries in metaData.Entry
                        where entries.Date.Day == DateTime.Now.AddDays(-1).Day
                        orderby entries.Date
                        select entries;

                Entries = await q.ExecuteAsync<EntityCollection<EntryEntity>>();
            }
        }

    }
}