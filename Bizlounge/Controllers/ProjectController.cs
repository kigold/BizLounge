using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bizlounge.Data;
using Microsoft.EntityFrameworkCore;
using Bizlounge.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Bizlounge.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProjectController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: Project
        [Authorize]
        public ActionResult Index()
        {
            var projects = _context.Project
                .Include(x => x.Payments)
                .Include(x => x.Slots)
                .Include(x => x.ProjectOwner)
                .ToList();            
            return View(projects);
        }

        // GET: Project/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var project = new ProjectViewModel();
            var projectData = _context.Project
                   .Include(x => x.Payments)
                   .Include(x => x.Slots)
                   .Include(x => x.ProjectOwner)
                   //.AsNoTracking()
                   .SingleOrDefault(m => m.ID == id);
            //check if null
            if (projectData == null)
            {
                return NotFound();
            }
            project.Project = projectData;
            project.ProjectOwner = projectData.ProjectOwner;
            project.Slots = projectData.Slots;
            project.Payments = projectData.Payments;
                       
            return View(project);
        }

        // GET: Project/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Project project)
        {
            try
            {
                // TODO: Add insert logic here
                //remove project Owner\
                //var userId = User.FindFirst("Id").ToString();
                var userId = _userManager.GetUserId(HttpContext.User);
                project.ProjectOwnerId = userId;
            
                if (ModelState.IsValid)
                {
                    _context.Project.Add(project);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return View();
            }
        }

        // GET: Project/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var project = new ProjectViewModel();
            var projectData = _context.Project
                   .Include(x => x.Payments)
                   .Include(x => x.Slots)
                   .Include(x => x.ProjectOwner)
                   //.AsNoTracking()
                   .SingleOrDefault(m => m.ID == id);
            //check if null
            if (projectData == null)
            {
                return NotFound();
            }
            project.Project = projectData;
            project.ProjectOwner = projectData.ProjectOwner;
            project.Slots = projectData.Slots;
            project.Payments = projectData.Payments;

            return View(project);
        }

        // POST: Project/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, ProjectViewModel projectData)
        {
            if (id != projectData.Project.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectData.Project);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    //Log the error (uncomment ex variable name and write a log.)
                }
            }
            return View(projectData);


        }

        // GET: Project/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }
            var project = new ProjectViewModel();
            var projectData = _context.Project
                   .Include(x => x.Payments)
                   .Include(x => x.Slots)
                   .Include(x => x.ProjectOwner)
                   //.AsNoTracking()
                   .SingleOrDefault(m => m.ID == id);
            //check if null
            if (projectData == null)
            {
                return NotFound();
            }
            project.Project = projectData;
            project.ProjectOwner = projectData.ProjectOwner;
            project.Slots = projectData.Slots;
            project.Payments = projectData.Payments;

            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProjectViewModel projectData)
        {
            try
            {
                // TODO: Add delete logic here
                if (id == projectData.Project.ID)
                {
                    Project project = _context.Project.Find(id);
                    _context.Project.Remove(project);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}