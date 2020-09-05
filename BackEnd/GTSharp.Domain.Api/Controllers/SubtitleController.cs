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

namespace GTSharp.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/subtitles")]
    // [Authorize]
    public class SubtitleController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateSubtitleCommand command, [FromServices] SubtitleHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("{id:int}")]
        [HttpGet]
        public Subtitle GetById([FromServices] ISubtitleRepository repository, int id)
        {
            return repository.GetById(id);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Subtitle> Get([FromServices] ISubtitleRepository repository)
        {
            return repository.GetAll();
        }
    }
}