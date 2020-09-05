using System;
using System.Linq;
using System.Collections.Generic;
using GTSharp.Domain.Commands.Input;
using GTSharp.Domain.Commands.Output;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GTSharp.Domain.Commands.Input.CreateCommand;
using GTSharp.Domain.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GTSharp.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/nodes")]
    // [Authorize]
    public class NodeController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateNodeCommand command, [FromServices] NodeHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("{id:int}")]
        [HttpGet]
        public Node GetById([FromServices] INodeRepository repository, int id)
        {
            return repository.GetById(id);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Node> Get([FromServices] DataContext context)
        {
            return context.Node.AsNoTracking()
                        .Include(o => o.Subtitles)
                        .Include(o => o.Recomendations)
                        .Include(o => o.Courses)
                            .ThenInclude(o => o.Comments);
        }
    }
}