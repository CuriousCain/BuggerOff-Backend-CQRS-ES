using Data_Layer.Models;
using System;

namespace Data_Layer.Events
{
    [Serializable()]
    public class BugOpened {
        public readonly Guid Id;
        public readonly int BugId;
        public readonly string BugDetails;

        public BugOpened(Bug bug)
        {
            Id = Guid.NewGuid();

            BugId = bug.ID;
            BugDetails = bug.Description;
        }
    }

	public class BugClosed { }

	public class BugReOpened { }

	public class BugFixed { }

}