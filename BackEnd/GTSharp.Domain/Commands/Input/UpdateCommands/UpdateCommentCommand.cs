using System;
using Flunt.Notifications;
using Flunt.Validations;
using GTSharp.Domain.Resources;
using GTSharp.Domain.Utils;

namespace GTSharp.Domain.Commands.Input.CreateCommand
{
    public class UpdateCommentCommand : Notifiable, ICommand
    {
        public int Id { get; set; }
        public string Title { get; set; }


        public UpdateCommentCommand(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()

            .IsBetween(Title.Length0IfNullOrEmpty(), 2, 1024, "Title", Messages.V_IsBetween.ToFormat("Title", "2", "1024"))

            .IsNotNull(Id, "Id", Messages.V_IsNotNullOrEmpty.ToFormat("Id"))
            );
        }
    }
}