using System;
using System.Collections.Generic;
using GTSharp.Domain.Entities;

namespace GTSharp.Domain.Repositories
{
    public interface IRoadMapRepository
    {
        RoadMap GetById(int id);
        IEnumerable<RoadMap> GetAll();
        void Create(RoadMap roadMap);
        void Update(RoadMap roadMap);
        void Delete(RoadMap roadMap);
    }
}