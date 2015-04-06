using Data_Layer.Models;
using System;
using System.Collections.Generic;

namespace Data_Layer.Interfaces
{
    public interface IBugQueryRepository
    {
        IEnumerable<Bug> AllBugs { get; }
        Bug GetByID(int id);
		IEnumerable<Bug> GetByFixed(bool isFixed);
    }
}