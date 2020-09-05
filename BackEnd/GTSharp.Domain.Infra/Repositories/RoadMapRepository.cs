using System.Collections.Generic;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Repositories;
using GTSharp.Domain.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GTSharp.Domain.Infra.Repositories
{
    public class RoadMapRepository : IRoadMapRepository
    {
        private readonly DataContext _context;

        public RoadMapRepository(DataContext context)
        {
            _context = context;
        }

        public RoadMap GetById(int id)
        {
            return _context.RoadMap.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<RoadMap> GetAll()
        {
            return _context.RoadMap.AsNoTracking();
        }

        public void Create(RoadMap RoadMap)
        {
            _context.RoadMap.Add(RoadMap);
            _context.SaveChanges();
        }
    }
}