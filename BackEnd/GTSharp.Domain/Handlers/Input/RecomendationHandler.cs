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
    public class RecomendationHandler :
    Notifiable,
    IHandler<CreateRecomendationCommand>,
    IHandler<UpdateRecomendationCommand>,
    IHandler<DeleteRecomendationCommand>
    {
        private readonly IRecomendationRepository _repository;

        public RecomendationHandler(IRecomendationRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateRecomendationCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            //Gera Recomendation
            var Recomendation = new Recomendation(command.Title,command.Url, command.Value, command.RecomendedByEid, command.NodeId);

            //Salva no banco
            _repository.Create(Recomendation);

            return new GenericCommandResult(true, Messages.Act_Save, Recomendation);
        }

        public ICommandResult Handle(UpdateRecomendationCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            var recomendation = _repository.GetById(command.Id);

            recomendation.UpdateRecomendation(command.Title,command.Url, command.Value, command.RecomendedByEid, command.IsApproved);

            _repository.Update(recomendation);
            
            return new GenericCommandResult(true, Messages.Act_Update, recomendation);
        }

        public ICommandResult Handle(DeleteRecomendationCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, Messages.Ex_ExceptionGeneric, command.Notifications);

            var recomendation = _repository.GetById(command.Id);
            
            if(recomendation == null)
                return new GenericCommandResult(false, Messages.Ex_ItemNotFound.ToFormat(command.Id.ToString() ?? ""), command.Notifications);

            _repository.Delete(recomendation);
            
            return new GenericCommandResult(true, Messages.Act_Deleted, recomendation);    
        }
    }
}