using Flunt.Notifications;
using GTSharp.Domain.Commands;
using GTSharp.Domain.Commands.Input.CreateCommand;
using GTSharp.Domain.Commands.Output;
using GTSharp.Domain.Handlers.Contract;
using GTSharp.Domain.Repositories;
using GTSharp.Domain.Resources;

namespace GTSharp.Domain.Entities
{
    public class CommentHandler :
    Notifiable,
    IHandler<CreateCommentCommand>
    {
        private readonly ICommentRepository _repository;

        public CommentHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateCommentCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            //Gera Comment
            var Comment = new Comment(command.Title, command.Eid, command.CourseId);

            //Salva no banco
            _repository.Create(Comment);

            return new GenericCommandResult(true, Messages.Act_Save, Comment);
        }

    }
}