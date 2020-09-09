using System;
using System.Collections.Generic;
using GTSharp.Domain.Entities;

namespace GTSharp.Domain.Repositories
{
    public interface ICommentRepository
    {
        Comment GetById(int id);
        IEnumerable<Comment> GetAll();
        void Create(Comment comment);
        void Update(Comment comment);
        void Delete(Comment comment);
    }
}