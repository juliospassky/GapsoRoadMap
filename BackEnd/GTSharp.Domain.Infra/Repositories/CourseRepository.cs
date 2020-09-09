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
    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext _context;

        public CourseRepository(DataContext context)
        {
            _context = context;
        }

        public Course GetById(int id)
        {
            return _context.Course.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Course.AsNoTracking();
        }

        public void Create(Course Course)
        {
            _context.Course.Add(Course);
            _context.SaveChanges();
        }

        public void Update(Course Course)
        {
            _context.Course.Update(Course);
            _context.SaveChanges();
        }

        public void Delete(Course Course)
        {
            _context.Course.Remove(Course);
            _context.SaveChanges();
        }
    }
}