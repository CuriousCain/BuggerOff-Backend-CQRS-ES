using Data_Layer.Models;
using System;
using System.Collections.Generic;

namespace Data_Layer.Interfaces
{
    public interface IBugRepository
    {
        IEnumerable<Bug> AllBugs { get; }
        void Add(Bug bug);
        Bug GetByID(int id);
        bool TryDelete(int id);
    }
}