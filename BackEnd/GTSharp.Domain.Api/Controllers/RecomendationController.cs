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
    [Route("v1/recomendations")]
    // [Authorize]
    public class RecomendationController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateRecomendationCommand command, [FromServices] RecomendationHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("{id:int}")]
        [HttpGet]
        public Recomendation GetById([FromServices] IRecomendationRepository repository, int id)
        {
            return repository.GetById(id);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Recomendation> Get([FromServices] IRecomendationRepository repository)
        {
            return repository.GetAll();
        }
    }
}