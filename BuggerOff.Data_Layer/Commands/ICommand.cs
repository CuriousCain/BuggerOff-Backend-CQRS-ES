using System;

namespace Data_Layer.Commands
{
    public interface ICommand
    {
		Guid Id { get; }
    }
}