using Flunt.Notifications;
using GTSharp.Domain.Commands;
using GTSharp.Domain.Commands.Input.CreateCommand;
using GTSharp.Domain.Commands.Output;
using GTSharp.Domain.Handlers.Contract;
using GTSharp.Domain.Repositories;
using GTSharp.Domain.Resources;

namespace GTSharp.Domain.Entities
{
    public class NodeHandler :
    Notifiable,
    IHandler<CreateNodeCommand>
    {
        private readonly INodeRepository _repository;

        public NodeHandler(INodeRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateNodeCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            //Gera Node
            var Node = new Node(command.Title, command.RoadMapId);

            //Salva no banco
            _repository.Create(Node);

            return new GenericCommandResult(true, Messages.Act_Save, Node);
        }

    }
}