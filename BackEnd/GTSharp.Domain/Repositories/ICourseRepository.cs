using System;
using System.Collections.Generic;
using GTSharp.Domain.Entities;

namespace GTSharp.Domain.Repositories
{
    public interface ICourseRepository
    {
        Course GetById(int id);
        IEnumerable<Course> GetAll();
        void Create(Course course);
    }
}