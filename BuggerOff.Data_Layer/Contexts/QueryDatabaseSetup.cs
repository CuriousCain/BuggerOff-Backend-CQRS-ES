using StackExchange.Redis;
using System;

namespace Data_Layer.Contexts
{
    public class QueryDatabaseSetup
    {
        public static ConnectionMultiplexer DBConnection { get; private set; }

        public static void SetDatabaseConnection(string connectionString)
        {
            DBConnection = ConnectionMultiplexer.Connect(connectionString);
        }
    }
}