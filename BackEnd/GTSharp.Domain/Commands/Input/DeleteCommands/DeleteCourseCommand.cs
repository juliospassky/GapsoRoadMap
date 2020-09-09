using System;
using Flunt.Notifications;
using Flunt.Validations;
using GTSharp.Domain.Resources;
using GTSharp.Domain.Utils;

namespace GTSharp.Domain.Commands.Input.CreateCommand
{
    public class DeleteCourseCommand : Notifiable, ICommand
    {
        public int Id { get; set; } 

        public DeleteCourseCommand(int id, string title)
        {
            Id = id;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()

            .IsNotNull(Id, "Id", Messages.V_IsNotNullOrEmpty.ToFormat("Id"))
            );
        }
    }
}