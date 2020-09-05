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
    public class NodeRepository : INodeRepository
    {
        private readonly DataContext _context;

        public NodeRepository(DataContext context)
        {
            _context = context;
        }

        public Node GetById(int id)
        {
            return _context.Node.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Node> GetAll()
        {
            return _context.Node.AsNoTracking();
        }

        public void Create(Node Node)
        {
            _context.Node.Add(Node);
            _context.SaveChanges();
        }
    }
}