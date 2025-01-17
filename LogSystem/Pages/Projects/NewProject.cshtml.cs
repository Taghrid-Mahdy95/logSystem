﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using LogSystemTutorial.DatabaseSpecific;
using LogSystemTutorial.EntityClasses;
using Microsoft.AspNetCore.Hosting;

namespace LogSystem.Pages
{
    public class NewProejctModel : PageModel
    {
        private readonly string[] _permittedExtensions = { ".jpg", ".png",".jpeg" };
        private readonly IWebHostEnvironment _iweb;

        [BindProperty]
        [Required]
        public IFormFile FileToUpload { set; get; }

        [BindProperty]
        [Required]
        public string ProjectName { set; get; }

        [BindProperty] 
        public ProjectEntity NewProject { set; get; } 
        
        [BindProperty] 
        public bool Extension { set; get; }


        public NewProejctModel(IWebHostEnvironment iweb)
        {
            _iweb = iweb;
            NewProject = new ProjectEntity();
        }

        public void OnGet()
        {
            Extension = true;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            NewProject.Name = ProjectName;

            var ext = Path.GetExtension(FileToUpload.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(ext) || !_permittedExtensions.Contains(ext))
            {
                Extension = false;
                return Page();
            }

            var filePath = Path.Combine(_iweb.WebRootPath,"Images",FileToUpload.FileName);
            using (var fileStream = System.IO.File.Create(filePath))
            {
                await FileToUpload.CopyToAsync(fileStream);
            }

            NewProject.Logo = filePath;


            using (var adapter = new DataAccessAdapter("Database=LogSystem;Server=localhost;Port=5432;User Id=postgres;Password=1234567890"))
            {
               await adapter.SaveEntityAsync(NewProject, true);
            }
            return RedirectToPage("Projects");
        }
    }
}