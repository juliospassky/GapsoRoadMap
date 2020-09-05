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
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _context;

        public CommentRepository(DataContext context)
        {
            _context = context;
        }

        public Comment GetById(int id)
        {
            return _context.Comment.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return _context.Comment.AsNoTracking();
        }

        public void Create(Comment Comment)
        {
            _context.Comment.Add(Comment);
            _context.SaveChanges();
        }
    }
}