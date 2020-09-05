using Flunt.Notifications;
using GTSharp.Domain.Commands;
using GTSharp.Domain.Commands.Input.CreateCommand;
using GTSharp.Domain.Commands.Output;
using GTSharp.Domain.Handlers.Contract;
using GTSharp.Domain.Repositories;
using GTSharp.Domain.Resources;

namespace GTSharp.Domain.Entities
{
    public class RoadMapHandler :
    Notifiable,
    IHandler<CreateRoadMapCommand>
    {
        private readonly IRoadMapRepository _repository;

        public RoadMapHandler(IRoadMapRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateRoadMapCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            //Gera RoadMap
            var RoadMap = new RoadMap(command.Title);

            //Salva no banco
            _repository.Create(RoadMap);

            return new GenericCommandResult(true, Messages.Act_Save, RoadMap);
        }

    }
}