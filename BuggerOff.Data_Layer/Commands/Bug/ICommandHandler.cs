using System;

namespace Data_Layer.Commands.Bug
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
		void Handle(TCommand command);

    }
}