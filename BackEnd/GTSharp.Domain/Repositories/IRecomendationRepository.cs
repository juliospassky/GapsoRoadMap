using System;
using System.Collections.Generic;
using GTSharp.Domain.Entities;

namespace GTSharp.Domain.Repositories
{
    public interface IRecomendationRepository
    {
        Recomendation GetById(int id);
        IEnumerable<Recomendation> GetAll();
        void Create(Recomendation recomendation);
        void Update(Recomendation recomendation);
        void Delete(Recomendation recomendation);
    }
}