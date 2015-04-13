using System;
using System.Collections.Generic;

namespace Data_Layer.Queries.Bug
{
    public interface IQueryHandler
    {
        List<object> GetBugSummary();
        void GetBugByID(int ID);
    }
}