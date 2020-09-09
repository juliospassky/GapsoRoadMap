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
    [Route("v1/roadMaps")]
    // [Authorize]
    public class RoadMapController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateRoadMapCommand command, [FromServices] RoadMapHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update([FromBody] UpdateRoadMapCommand command, [FromServices] RoadMapHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpDelete]
        public GenericCommandResult Delete([FromBody] DeleteRoadMapCommand command, [FromServices] RoadMapHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("{id:int}")]
        [HttpGet]
        public RoadMap GetById([FromServices] DataContext context, int id)
        {
            return context.RoadMap.AsNoTracking().Where(o => o.Id == id)
                        .Include(o => o.Nodes)
                            .ThenInclude(o => o.Subtitles)
                        .Include(o => o.Nodes)
                            .ThenInclude(o => o.Courses)
                                .ThenInclude(o => o.Comments)
                        .Include(o => o.Nodes)
                            .ThenInclude(o => o.Recomendations).FirstOrDefault();
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<RoadMap> Get([FromServices] DataContext context)
        {
            return context.RoadMap.AsNoTracking()
                        .Include(o => o.Nodes)
                            .ThenInclude(o => o.Subtitles)
                        .Include(o => o.Nodes)
                            .ThenInclude(o => o.Courses)
                                .ThenInclude(o => o.Comments)
                        .Include(o => o.Nodes)
                            .ThenInclude(o => o.Recomendations);
        }
    }
}