using Data_Layer.Models;
using System;

namespace Data_Layer.Events
{
    [Serializable()]
    public class BugOpened {
        
        public readonly Guid Id;
        public readonly int BugId;
        public readonly string BugDetails;
        public readonly bool BugFixed;

        public BugOpened(Bug bug)
        {
            Id = Guid.NewGuid();

            BugId = bug.ID;
            BugDetails = bug.Description;
            BugFixed = bug.Fixed;
        }
    }

	public class BugClosed { }

	public class BugReOpened { }

	public class BugFixed { }

}