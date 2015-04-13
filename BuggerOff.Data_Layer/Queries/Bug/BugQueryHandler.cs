using Data_Layer.Contexts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Data_Layer.Queries.Bug
{
    public class BugQueryHandler : IQueryHandler
    {
        public void GetBugByID(int ID)
        {
            var db = QueryDatabaseSetup.DBConnection.GetDatabase();
            //TODO: Implement BugDetail in Redis DB
        }

        public List<object> GetBugSummary()
        {
            var db = QueryDatabaseSetup.DBConnection.GetDatabase();
            var resultsList = new List<object>();

            foreach(var item in db.SetMembers("BugSummary")) //TODO: MAGIC STRING!
            {
                resultsList.Add(JsonConvert.DeserializeObject(item));
            }

            return resultsList;
        }
    }
}