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
    public class NodeHandler :
    Notifiable,
    IHandler<CreateNodeCommand>,
    IHandler<UpdateNodeCommand>,
    IHandler<DeleteNodeCommand>
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

        public ICommandResult Handle(UpdateNodeCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            var node = _repository.GetById(command.Id);

            node.UpdateNode(command.Title);

            _repository.Update(node);
            
            return new GenericCommandResult(true, Messages.Act_Update, node);
        }

        public ICommandResult Handle(DeleteNodeCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            var node = _repository.GetById(command.Id);
            
            if(node == null)
                return new GenericCommandResult(false, Messages.Ex_ItemNotFound.ToFormat(command.Id.ToString() ?? ""), command.Notifications);

            _repository.Delete(node);
            
            return new GenericCommandResult(true, Messages.Act_Deleted, node);     
        }
    }
}