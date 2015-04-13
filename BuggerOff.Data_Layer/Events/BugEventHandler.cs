using System;
using EventStore.ClientAPI;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using StackExchange.Redis;
using Data_Layer.Contexts;

namespace Data_Layer.Events
{
    public class BugEventHandler
    {
        private IEventStoreConnection eventStoreConnection;
        private ConnectionMultiplexer redisConnection;

        public BugEventHandler()
        {
            ConnectToEventStore();
        }

        public void Handle(BugOpened bugOpened)
        {
            var serializedData = SerializeToJsonBytes(bugOpened, bugOpened);

            var newEvent = new EventData(bugOpened.Id, "BugOpened", false, serializedData.Item1, serializedData.Item2);

            eventStoreConnection.AppendToStreamAsync("devstream", ExpectedVersion.Any, newEvent).Wait();

            IDatabase db = QueryDatabaseSetup.DBConnection.GetDatabase();

            var newBugValue = new RedisValue();
            newBugValue = JsonConvert.SerializeObject(bugOpened);
            db.SetAdd("BugSummary", newBugValue);
        }

        public void ConnectToEventStore()
        {
            eventStoreConnection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
            eventStoreConnection.ConnectAsync().Wait();
        }


        private Tuple<byte[], byte[]> SerializeToJsonBytes(object bugEvent, object bugEventMeta)
        {
            var serializedBugEvent = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(bugEvent));
            var serializedBugEventMeta = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(bugEventMeta));
            
            return new Tuple<byte[], byte[]>(serializedBugEvent, serializedBugEventMeta);
        }
    }
}