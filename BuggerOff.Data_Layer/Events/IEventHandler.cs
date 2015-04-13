using System;

namespace Data_Layer.Events
{
    public interface IEventHandler
    {
		void Handle(BugOpened bugOpened);
    }
}