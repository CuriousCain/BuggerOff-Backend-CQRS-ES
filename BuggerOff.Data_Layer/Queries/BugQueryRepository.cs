using Data_Layer.Interfaces;
using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Layer.Queries
{
    public class BugQueryRepository : IBugQueryRepository
    {
		readonly List<Bug> bugs = new List<Bug>();

		public IEnumerable<Bug> AllBugs
		{
			get
			{
				return bugs;
			}
		}

		public Bug GetByID(int id)
		{
			return bugs.FirstOrDefault(x => x.ID == id);
		}

		public IEnumerable<Bug> GetByFixed(bool isFixed)
		{
			throw new NotImplementedException();
		}
	}
}