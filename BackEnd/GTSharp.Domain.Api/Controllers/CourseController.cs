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

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update([FromBody] UpdateCourseCommand command, [FromServices] CourseHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpDelete]
        public GenericCommandResult Delete([FromBody] DeleteCourseCommand command, [FromServices] CourseHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("{id:int}")]
        [HttpGet]
        public Course GetById([FromServices] DataContext context, int id)
        {
            return context.Course.AsNoTracking().Where(o => o.Id == id)
                        .Include(o => o.Comments).FirstOrDefault();
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Course> Get([FromServices] DataContext context)
        {
            return context.Course.AsNoTracking()
                        .Include(o => o.Comments);
        }
    }
}