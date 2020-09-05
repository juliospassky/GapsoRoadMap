using System;
using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Resources;
using GTSharp.Domain.Utils;

namespace GTSharp.Domain.Commands.Input.CreateCommand
{
    public class CreateNodeCommand : Notifiable, ICommand
    {
        public string Title { get;  set; }
        List<Subtitle> Subtitles { get; set; }
        List<Course> Courses { get; set; }
        List<Recomendation> Recomendations { get; set; }
        public int RoadMapId { get;  set; }

        public CreateNodeCommand(string title, int roadMapId)
        {
            Title = title;
            RoadMapId = roadMapId;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()

            .IsBetween(Title.Length0IfNullOrEmpty(), 2, 128, "Title", Messages.V_IsBetween.ToFormat("Title", "2", "128"))

            .IsNotNull(RoadMapId, "RoadMapId", Messages.V_IsNotNullOrEmpty.ToFormat("RoadMapId"))
            );
        }
    }
}