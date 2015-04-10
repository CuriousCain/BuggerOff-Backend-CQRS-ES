using System;
using EventStore.ClientAPI;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Data_Layer.Events
{
    public class BugEventHandler
    {
        public void Handle(BugOpened bugOpened)
        {
            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
            connection.ConnectAsync().Wait();

            var serializedData = SerializeToJsonBytes(bugOpened, bugOpened);

            var newEvent = new EventData(bugOpened.Id, "BugOpened", false, serializedData.Item1, serializedData.Item2);

            connection.AppendToStreamAsync("devstream", ExpectedVersion.Any, newEvent).Wait();
        }

        private Tuple<byte[], byte[]> SerializeToJsonBytes(object bugEvent, object bugEventMeta)
        {
            var serializedBugEvent = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(bugEvent));
            var serializedBugEventMeta = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(bugEventMeta));
            
            return new Tuple<byte[], byte[]>(serializedBugEvent, serializedBugEventMeta);
        }
    }
}