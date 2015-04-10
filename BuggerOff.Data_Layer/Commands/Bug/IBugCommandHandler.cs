using System;

namespace Data_Layer.Commands.Bug
{
    public interface IBugCommandHandler
    {
		void Handle(OpenBug command);
		void Handle(CloseBug command);
		void Handle(CloseMultipleBugs command);
    }
}