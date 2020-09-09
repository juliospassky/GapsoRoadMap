using System.Collections.Generic;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Repositories;
using GTSharp.Domain.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using GTSharp.Domain.Queries;
using System;

namespace GTSharp.Domain.Infra.Repositories
{
    public class RecomendationRepository : IRecomendationRepository
    {
        private readonly DataContext _context;

        public RecomendationRepository(DataContext context)
        {
            _context = context;
        }

        public Recomendation GetById(int id)
        {
            return _context.Recomendation.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Recomendation> GetAll()
        {
            return _context.Recomendation.AsNoTracking();
        }

        public void Create(Recomendation Recomendation)
        {
            _context.Recomendation.Add(Recomendation);
            _context.SaveChanges();
        }
        
        public void Update(Recomendation Recomendation)
        {
            _context.Recomendation.Update(Recomendation);
            _context.SaveChanges();
        }

        public void Delete(Recomendation Recomendation)
        {
            _context.Recomendation.Remove(Recomendation);
            _context.SaveChanges();
        }
    }
}