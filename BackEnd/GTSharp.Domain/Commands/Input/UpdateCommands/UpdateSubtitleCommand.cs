using System;
using Flunt.Notifications;
using Flunt.Validations;
using GTSharp.Domain.Resources;
using GTSharp.Domain.Utils;

namespace GTSharp.Domain.Commands.Input.CreateCommand
{
    public class UpdateSubtitleCommand : Notifiable, ICommand
    {
        public int Id { get; private set; }
        public string Title { get; set; }

        public UpdateSubtitleCommand(int id, string title, int nodeId)
        {
            Id = id;
            Title = title;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()

            .IsBetween(Title.Length0IfNullOrEmpty(), 2, 128, "Title", Messages.V_IsBetween.ToFormat("Title", "2", "128"))

            .IsNotNull(Id, "Id", Messages.V_IsNotNullOrEmpty.ToFormat("Id"))
            );
        }
    }
}