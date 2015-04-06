using Data_Layer.Interfaces;
using System;
using Data_Layer.Models;
using System.Collections.Generic;
using System.Linq;

namespace Data_Layer.Repositories
{
    public class BugRepository : IBugRepository
    {
        readonly List<Bug> bugs = new List<Bug>();
        public IEnumerable<Bug> AllBugs
        {
            get
            {
                return bugs;
            }
        }

        public void Add(Bug bug)
        {
            bug.ID = 1 + bugs.Max(x => (int?)x.ID) ?? 0;
			bug.Fixed = false; //New bugs should not already be fixed
            bugs.Add(bug);
        }

        public Bug GetByID(int id)
        {
            return bugs.FirstOrDefault(x => x.ID == id);
        }

        public bool TryDelete(int id)
        {
            var bug = GetByID(id);

            if (bug == null)
                return false;

            bugs.Remove(bug);
            return true;
        }
    }
}