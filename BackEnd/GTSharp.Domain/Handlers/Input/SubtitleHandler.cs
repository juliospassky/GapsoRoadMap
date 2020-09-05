using Flunt.Notifications;
using GTSharp.Domain.Commands;
using GTSharp.Domain.Commands.Input.CreateCommand;
using GTSharp.Domain.Commands.Output;
using GTSharp.Domain.Handlers.Contract;
using GTSharp.Domain.Repositories;
using GTSharp.Domain.Resources;

namespace GTSharp.Domain.Entities
{
    public class SubtitleHandler :
    Notifiable,
    IHandler<CreateSubtitleCommand>
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

    }
}