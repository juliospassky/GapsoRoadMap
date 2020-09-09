using System;
using Flunt.Notifications;
using Flunt.Validations;
using GTSharp.Domain.Resources;
using GTSharp.Domain.Utils;

namespace GTSharp.Domain.Commands.Input.CreateCommand
{
    public class CreateSubtitleCommand : Notifiable, ICommand
    {
        public string Title { get; set; }
        public int NodeId { get; set; }

        public CreateSubtitleCommand(string title, int nodeId)
        {
            Title = title;
            NodeId = nodeId;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()

            .IsBetween(Title.Length0IfNullOrEmpty(), 2, 128, "Title", Messages.V_IsBetween.ToFormat("Title", "2", "128"))

            .IsNotNull(NodeId, "NodeId", Messages.V_IsNotNullOrEmpty.ToFormat("NodeId"))
            );
        }
    }
}