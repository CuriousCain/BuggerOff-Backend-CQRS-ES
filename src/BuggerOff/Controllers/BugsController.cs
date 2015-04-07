using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Data_Layer.Interfaces;
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
		private readonly IBugRepository bugRepository;
		private BugCommandHandler commandHandler;
		private BugContext db;

		public BugsController(IBugRepository repository, BugContext bugContext)
		{
			bugRepository = repository;
			db = bugContext;
			commandHandler = new BugCommandHandler(db);
		}

		[HttpGet]
		public IEnumerable<Bug> GetAll()
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
		public IActionResult CreateBug([FromBody] Bug bug) //TODO: Don't use full object as parameter
		{
			if (!ModelState.IsValid)
			{
				return new HttpStatusCodeResult(400);
			}
			else
			{
				commandHandler.Handle(new OpenBug(bug));

				return new HttpStatusCodeResult(201);
			}
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteBug(int id)
		{
			if (bugRepository.TryDelete(id))
			{
				return new HttpStatusCodeResult(204);
			}
			else
			{
				return HttpNotFound();
			}
		}
	}
}
