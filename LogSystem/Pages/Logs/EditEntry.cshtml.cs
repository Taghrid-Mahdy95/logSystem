﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogSystemTutorial.EntityClasses;
using LogSystemTutorial.HelperClasses;
using LogSystemTutorial.DatabaseSpecific;
using LogSystemTutorial.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Microsoft.AspNetCore.Mvc.Rendering;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Threading.Tasks;
using System.Linq;

namespace LogSystem.Pages.Logs
{
    public class EditEntryModel : PageModel
    {
        [BindProperty] 
        public EntryEntity OldEntry { set; get; }
        
        [BindProperty] 
        public EntityCollection<ProjectEntity> AllProjects { set; get; }
        
        [BindProperty] 
        public string NewSelectedProjectId { set; get; }
        
        [BindProperty] 
        public ProjectEntity OldSelectedProject { set; get; }
        
        [BindProperty] 
        public bool OldEntryProject { set; get; }

        public async void OnGetAsync(long id)
        {
            //            OldEntry = new EntryEntity(id);
            //            using (DataAccessAdapter adapter = new DataAccessAdapter("Database=logsSystem;Server=localhost;Port=5432;User Id=postgres;Password=1234567"))
            //            {
            //                adapter.FetchEntity(OldEntry);
            //
            //                OldSelectedProject = new ProjectEntity(OldEntry.ProjectId.Value);
            //                OldEntryProject = adapter.FetchEntity(OldSelectedProject);
            //
            //            }
            var entities = new EntityCollection<EntryEntity>();
            var projects = new EntityCollection<ProjectEntity>();

            using (DataAccessAdapter adapter = new DataAccessAdapter("Database=LogSystem;Server=localhost;Port=5432;User Id=postgres;Password=1234567890"))
            {
                var metaData = new LinqMetaData(adapter);

                var q = metaData.Entry.Where (x => x.Id == id)
                    .WithPath(x => x.Prefetch(y => y.Project));

                entities = await q.ExecuteAsync<EntityCollection<EntryEntity>>();
                OldEntry = entities[0];

                //projects = await q.ExecuteAsync<EntityCollection<ProjectEntity>>();

                if (OldEntry.Project != null)
                {
                    var queryProjectsNotExist = from project in metaData.Project
                            where project.Status == true && project.Id != OldEntry.Project.Id
                            select project;
                    AllProjects = await queryProjectsNotExist.ExecuteAsync<EntityCollection<ProjectEntity>>();
                }
                else
                {
                    var queryProjectExist = from project in metaData.Project
                            where project.Status == true
                            select project;
                    AllProjects = await queryProjectExist.ExecuteAsync<EntityCollection<ProjectEntity>>();
                }
            }

        }
        public async Task<IActionResult> OnPostAsync()
        {
            var updatedEntry = new EntryEntity();
            updatedEntry.Id = OldEntry.Id;
            updatedEntry.Description = OldEntry.Description;
            updatedEntry.TimeSpent = OldEntry.TimeSpent;
            updatedEntry.ProjectId = long.Parse(NewSelectedProjectId);
            updatedEntry.IsNew = false;

            using (DataAccessAdapter adapter = new DataAccessAdapter("Database=logsSystem;Server=localhost;Port=5432;User Id=postgres;Password=1234567"))
            {
               await adapter.SaveEntityAsync(updatedEntry);
            }
            return RedirectToPage("Logs");
        }
    }
}