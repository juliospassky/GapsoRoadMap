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
    public class RoadMapHandler :
    Notifiable,
    IHandler<CreateRoadMapCommand>,
    IHandler<UpdateRoadMapCommand>,
    IHandler<DeleteRoadMapCommand>
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

        public ICommandResult Handle(UpdateRoadMapCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            var roadMap = _repository.GetById(command.Id);

            roadMap.UpdateRoadMap(command.Title);

            _repository.Update(roadMap);
            
            return new GenericCommandResult(true, Messages.Act_Update, roadMap);
        }

        public ICommandResult Handle(DeleteRoadMapCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            var roadMap = _repository.GetById(command.Id);
            
            if(roadMap == null)
                return new GenericCommandResult(false, Messages.Ex_ItemNotFound.ToFormat(command.Id.ToString() ?? ""), command.Notifications);

            _repository.Delete(roadMap);
            
            return new GenericCommandResult(true, Messages.Act_Deleted, roadMap);  
        }
    }
}