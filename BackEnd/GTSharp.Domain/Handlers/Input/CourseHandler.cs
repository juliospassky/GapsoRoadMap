using Flunt.Notifications;
using GTSharp.Domain.Commands;
using GTSharp.Domain.Commands.Input.CreateCommand;
using GTSharp.Domain.Commands.Output;
using GTSharp.Domain.Handlers.Contract;
using GTSharp.Domain.Repositories;
using GTSharp.Domain.Resources;
using GTSharp.Domain.Utils;

namespace GTSharp.Domain.Entities
{
    public class CourseHandler :
    Notifiable,
    IHandler<CreateCourseCommand>,
    IHandler<UpdateCourseCommand>,
    IHandler<DeleteCourseCommand>

    {
        private readonly ICourseRepository _repository;

        public CourseHandler(ICourseRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateCourseCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            //Gera Course
            var Course = new Course(command.Title, command.Url, command.Value, command.Stars, command.RecomendedByEid, command.NodeId);

            //Salva no banco
            _repository.Create(Course);

            return new GenericCommandResult(true, Messages.Act_Save, Course);
        }

        public ICommandResult Handle(UpdateCourseCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            var course = _repository.GetById(command.Id);

            course.UpdateCourse(command.Title, command.Url, command.Value, command.Stars, command.RecomendedByEid);

            _repository.Update(course);

            return new GenericCommandResult(true, Messages.Act_Update, course);
        }

        public ICommandResult Handle(DeleteCourseCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            var course = _repository.GetById(command.Id);
            
            if(course == null)
                return new GenericCommandResult(false, Messages.Ex_ItemNotFound.ToFormat(command.Id.ToString() ?? ""), command.Notifications);

            _repository.Delete(course);
            
            return new GenericCommandResult(true, Messages.Act_Deleted, course);     
        }
    }
}