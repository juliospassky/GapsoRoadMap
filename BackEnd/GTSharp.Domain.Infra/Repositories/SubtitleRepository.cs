using System.Collections.Generic;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Repositories;
using GTSharp.Domain.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GTSharp.Domain.Infra.Repositories
{
    public class SubtitleRepository : ISubtitleRepository
    {
        private readonly DataContext _context;

        public SubtitleRepository(DataContext context)
        {
            _context = context;
        }

        public Subtitle GetById(int id)
        {
            return _context.Subtitle.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Subtitle> GetAll()
        {
            return _context.Subtitle.AsNoTracking();
        }

        public void Create(Subtitle Subtitle)
        {
            _context.Subtitle.Add(Subtitle);
            _context.SaveChanges();
        }
    }
}