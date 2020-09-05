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
    [Route("v1/courses")]
    // [Authorize]
    public class CourseController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateCourseCommand command, [FromServices] CourseHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("{id:int}")]
        [HttpGet]
        public Course GetById([FromServices] ICourseRepository repository, int id)
        {
            return repository.GetById(id);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Course> Get([FromServices] ICourseRepository repository)
        {
            return repository.GetAll();
        }
    }
}