using System;
using System.Collections.Generic;
using GTSharp.Domain.Entities;

namespace GTSharp.Domain.Repositories
{
    public interface ISubtitleRepository
    {
        Subtitle GetById(int id);
        IEnumerable<Subtitle> GetAll();
        void Create(Subtitle subtitle);
        void Update(Subtitle subtitle);
        void Delete(Subtitle subtitle);
    }
}