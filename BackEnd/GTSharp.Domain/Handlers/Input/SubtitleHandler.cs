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
    public class SubtitleHandler :
    Notifiable,
    IHandler<CreateSubtitleCommand>,
    IHandler<UpdateSubtitleCommand>,
    IHandler<DeleteSubtitleCommand>
    {
        private readonly ISubtitleRepository _repository;

        public SubtitleHandler(ISubtitleRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateSubtitleCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            //Gera Subtitle
            var Subtitle = new Subtitle(command.Title, command.NodeId);

            //Salva no banco
            _repository.Create(Subtitle);

            return new GenericCommandResult(true, Messages.Act_Save, Subtitle);
        }

        public ICommandResult Handle(UpdateSubtitleCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            var subtitle = _repository.GetById(command.Id);

            subtitle.UpdateSubtitle(command.Title);

            _repository.Update(subtitle);
            
            return new GenericCommandResult(true, Messages.Act_Update, subtitle);
        }

        public ICommandResult Handle(DeleteSubtitleCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            var subtitle = _repository.GetById(command.Id);
            
            if(subtitle == null)
                return new GenericCommandResult(false, Messages.Ex_ItemNotFound.ToFormat(command.Id.ToString() ?? ""), command.Notifications);

            _repository.Delete(subtitle);
            
            return new GenericCommandResult(true, Messages.Act_Deleted, subtitle);
        }
    }
}