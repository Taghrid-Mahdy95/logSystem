﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using LogSystemTutorial.HelperClasses;
using LogSystemTutorial.EntityClasses;
using LogSystemTutorial.DatabaseSpecific;
using LogSystemTutorial.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace LogSystem.Pages.Logs
{
    public class ProjectsModel : PageModel
    {
        [BindProperty] 
        public EntityCollection<ProjectEntity> AllProjects { set; get; }

        public async void OnGetAsync()
        {
            using (var adapter = new DataAccessAdapter("Database=LogSystem;Server=localhost;Port=5432;User Id=postgres;Password=1234567890"))
            {
                var metadata = new LinqMetaData(adapter);
                AllProjects = await metadata.Project.ExecuteAsync<EntityCollection<ProjectEntity>>();
            }
        }

        public RedirectToPageResult OnPostDeActivate(int id)
        {
            var deactivatedProject = new ProjectEntity();
            deactivatedProject.Id = id;
            deactivatedProject.Status = false;
            deactivatedProject.IsNew = false;
            using (var adapter = new DataAccessAdapter("Database=logsSystem;Server=localhost;Port=5432;User Id=postgres;Password=1234567"))
            {
                adapter.SaveEntity(deactivatedProject);
            }
            return RedirectToPage("Projects");
        }
    }
}
