using System;
using System.Collections.Generic;
using GTSharp.Domain.Entities;

namespace GTSharp.Domain.Repositories
{
    public interface INodeRepository
    {
        Node GetById(int id);
        IEnumerable<Node> GetAll();
        void Create(Node Node);
    }
}