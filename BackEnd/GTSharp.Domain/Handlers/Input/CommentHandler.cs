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
    public class CommentHandler :
    Notifiable,
    IHandler<CreateCommentCommand>,
    IHandler<UpdateCommentCommand>,
    IHandler<DeleteCommentCommand>
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

        public ICommandResult Handle(UpdateCommentCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            var comment = _repository.GetById(command.Id);

            comment.UpdateTitle(command.Title);

            _repository.Update(comment);
            
            return new GenericCommandResult(true, Messages.Act_Update, comment);
        }

        public ICommandResult Handle(DeleteCommentCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            var comment = _repository.GetById(command.Id);
            
            if(comment == null)
                return new GenericCommandResult(false, Messages.Ex_ItemNotFound.ToFormat(command.Id.ToString() ?? ""), command.Notifications);

            _repository.Delete(comment);
            
            return new GenericCommandResult(true, Messages.Act_Deleted, comment);            
        }
    }
}