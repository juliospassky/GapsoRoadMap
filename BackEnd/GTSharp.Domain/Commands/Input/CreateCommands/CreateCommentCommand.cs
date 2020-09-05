using System;
using Flunt.Notifications;
using Flunt.Validations;
using GTSharp.Domain.Resources;
using GTSharp.Domain.Utils;

namespace GTSharp.Domain.Commands.Input.CreateCommand
{
    public class CreateCommentCommand : Notifiable, ICommand
    {
        public string Title { get; set; }
        public string Eid { get; set; }
        public int? CourseId { get; set; }

        public CreateCommentCommand(string title, string eid, int? courseId)
        {
            Title = title;
            Eid = eid;
            CourseId = courseId;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()

            .IsBetween(Title.Length0IfNullOrEmpty(), 2, 1024, "Title", Messages.V_IsBetween.ToFormat("Title", "2", "1024"))
            .IsBetween(Eid.Length0IfNullOrEmpty(), 2, 128, "Eid", Messages.V_IsBetween.ToFormat("Eid", "2", "128"))

            .IsNotNull(CourseId, "CourseId", Messages.V_IsNotNullOrEmpty.ToFormat("CourseId"))
            );
        }
    }
}