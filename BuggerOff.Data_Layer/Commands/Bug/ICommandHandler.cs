using System;

namespace Data_Layer.Commands.Bug
{
    public interface ICommandHandler
    {
		void Handle(OpenBug command);		
		void Handle(CloseBug command);		
		void Handle(CloseMultipleBugs command);
    }
}