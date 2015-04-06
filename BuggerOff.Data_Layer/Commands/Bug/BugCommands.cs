using System;
using Data_Layer.Models;

namespace Data_Layer.Commands.Bug
{
	public class OpenBug : ICommand
	{
		public Guid Id { get; set; }
		public Models.Bug NewBug { get; set; }
		public OpenBug(Models.Bug bug) {
			Id = Guid.NewGuid();
			NewBug = bug;
		}
	}

	public class CloseBug : ICommand
	{
		public Guid Id { get; set; }
		public CloseBug()
		{
			Id = Guid.NewGuid();
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

	public class FixBug
	{
		public Guid Id { get; set; }
		public FixBug()
		{
			Id = Guid.NewGuid();
		}
	}
}