using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMScreenInterview.Data;
using AMScreenInterview.Models.Entities;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace AMScreenInterview.Controllers
{
    public class IssuesController : Controller
    {
        private readonly AMScreenContext _context;

        public IssuesController(AMScreenContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Issues index view, show all issues.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            // Get all screen issues
            List<ScreenIssues> issues = await _context.ScreenIssues.ToListAsync();

            // Fill the model with issue and screen data
            foreach(ScreenIssues issue in issues)
            {
                    issue.Issue = await _context.Issue.FindAsync(issue.IssueId);
                    issue.Screen = await _context.Screen.FindAsync(issue.IssueId);
            }

            // Display view
            return View(issues);
        }

        /// <summary>
        /// Create view for assigning an engineer to an issue.
        /// </summary>
        /// <param name="id">Issue id</param>
        /// <returns></returns>
        public async Task<IActionResult> AssignEngineer(int? id)
        {
            // If no issue ID is entered, dispaly 404 error
            if(id == null)
            {
                return NotFound();
            }
            
            // Compile all engineers to array for view and store issue id
            ViewData["Engineers"] = await _context.Engineer.ToArrayAsync();
            ViewData["IssueId"] = id;

            return View();
        }

        /// <summary>
        /// Handle the POST action on the assign engineer form
        /// </summary>
        /// <param name="issueId">ID of issue engineer is being assigned to</param>
        /// <param name="engineerId">Engingeer's id</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignEngineer(int issueId, int engineerId)
        {
            // Create and fill a EngineerJob model
            EngineerJobs engineerJob = new EngineerJobs
            {
                EngineerId = engineerId,
                IssueId = issueId,
                Date = DateTime.Now
            };

            // Store and save the new data to database
            _context.Add(engineerJob);
            await _context.SaveChangesAsync();

            // Redirect to index
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Returns view for reporting new screen issues.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Report()
        {
            // Gather all screens and possible issues
            ViewData["Issues"] = await _context.Issue.ToArrayAsync();
            ViewData["Screens"] = await _context.Screen.ToArrayAsync();

            // Display view
            return View();
        }

        /// <summary>
        /// Handles the HTTP POST from the Report form, adding a new screen issue to the database.
        /// </summary>
        /// <param name="issueId">Id of the issue</param>
        /// <param name="screenId">Id of the screen the issue if for</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Report(int issueId, int screenId)
        {
            // Create the new screen issue
            ScreenIssues screenIssue = new ScreenIssues
            {
                IssueId = issueId,
                ScreenId = screenId,
                DateReported = DateTime.Now
            };

            // Add the screenissue to the database and save
            _context.Add(screenIssue);
            await _context.SaveChangesAsync();

            // Redirect to index
            return RedirectToAction(nameof(Index));
        }
    }
}
