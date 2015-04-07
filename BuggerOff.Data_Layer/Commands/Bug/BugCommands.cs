using System;
using Data_Layer.Models;

namespace Data_Layer.Commands.Bug
{
	public class OpenBug : ICommand
	{
		public Guid Id { get; set; }
		public Models.Bug NewBug { get; set; }
		public OpenBug(string details) {
			Id = Guid.NewGuid();
			NewBug = new Models.Bug();
			NewBug.Description = details;
			NewBug.Fixed = false;
		}
	}

	public class CloseBug : ICommand
	{
		public Guid Id { get; set; }
		public int BugID { get; set; }
		public CloseBug(int bugID)
		{
			Id = Guid.NewGuid();
			BugID = bugID;
		}
	}

	public class CloseMultipleBugs : ICommand
	{
		public Guid Id { get; set; }
		public int[] BugIDs { get; set; }

		public CloseMultipleBugs(int[] bugIds)
		{
			Id = Guid.NewGuid();
			BugIDs = bugIds;
		}
	}

	public class ReOpenBug
	{
		public Guid Id { get; set; }
		public ReOpenBug()
		{
			Id = Guid.NewGuid();
		}
	}
}