using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Data_Layer.Models;
using Data_Layer.Commands.Bug;
using Data_Layer.Contexts;
using StackExchange.Redis;
using Newtonsoft.Json;
using Data_Layer.Queries.Bug;

namespace BuggerOff.Controllers
{
	//Route is set in Startup: /bugs/[action]
	public class BugsController : Controller
	{
		private ICommandHandler commandHandler;
        private IQueryHandler queryHandler;
		private BugContext db;

		public BugsController(BugContext bugContext, ICommandHandler bugCommandHandler, IQueryHandler bugQueryHandler)
		{
			db = bugContext;
			commandHandler = bugCommandHandler;
            queryHandler = bugQueryHandler;
		}

        [HttpGet]
        public IActionResult All()
        {
            
            return new ObjectResult(queryHandler.GetBugSummary());
        }

		[HttpGet]
		public IActionResult GetByID(int id)
		{
            queryHandler.GetBugByID(id);
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
