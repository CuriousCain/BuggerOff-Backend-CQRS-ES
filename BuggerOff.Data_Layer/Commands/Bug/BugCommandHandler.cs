using Data_Layer.Contexts;
using Data_Layer.Interfaces;
using System;

namespace Data_Layer.Commands.Bug
{
    public class BugCommandHandler
    {
		private IBugRepository bugRepo;
		private BugContext db;

		public BugCommandHandler(IBugRepository repo, BugContext bugContext)
		{
			bugRepo = repo;
			db = bugContext;
		}

		public void Handle(OpenBug command)
		{
			var bug = command.NewBug;

			db.Add(bug);
			db.SaveChanges();
		}
    }
}