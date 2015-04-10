using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Data_Layer.Models;
using Data_Layer.Commands.Bug;
using Microsoft.Data.Entity;
using Data_Layer.Contexts;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BuggerOff.Controllers
{
	//Route is set in Startup: /bugs/[action]
	public class BugsController : Controller
	{
		private ICommandHandler commandHandler;
		private BugContext db;

		public BugsController(BugContext bugContext, ICommandHandler bugCommandHandler)
		{
			db = bugContext;
			commandHandler = bugCommandHandler;
		}

		[HttpGet]
		public IEnumerable<Bug> All()
		{
            return db.Bugs; //TODO: Use database cache (query database)
		}

		[HttpGet]
		public IActionResult GetByID(int id)
		{
            var bug = db.Bugs.SingleOrDefault(x => x.ID == id);

            if (bug == null)
                return new HttpNotFoundResult();

			return new ObjectResult(bug);
		}

		[HttpPost]
		public IActionResult OpenBug([FromBody] Bug bug)
		{
			if (!ModelState.IsValid)
			{
				return new HttpStatusCodeResult(400);
			}
			else
			{
				commandHandler.Handle(new OpenBug(bug.Description));

				return new HttpStatusCodeResult(201);
			}
		}

		[HttpPost]
		public IActionResult CloseBug(int id)
		{
			commandHandler.Handle(new CloseBug(id));

			return new HttpStatusCodeResult(202);
		}

		[HttpPost]
		public IActionResult CloseMultipleBugs([FromBody] int[] bugIds)
		{
			commandHandler.Handle(new CloseMultipleBugs(bugIds));

			return new HttpStatusCodeResult(202);
		}
	}
}
