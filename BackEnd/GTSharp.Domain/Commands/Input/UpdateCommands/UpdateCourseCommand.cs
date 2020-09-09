using System;
using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Resources;
using GTSharp.Domain.Utils;

namespace GTSharp.Domain.Commands.Input.CreateCommand
{
    public class UpdateCourseCommand : Notifiable, ICommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public Decimal Value { get; set; }
        public Decimal Stars { get; set; }
        public string RecomendedByEid { get; set; }

        public UpdateCourseCommand(int id, string title, string url, decimal value, decimal stars, string recomendedByEid)
        {
            Id = id;
            Title = title;
            Url = url;
            Value = value;
            Stars = stars;
            RecomendedByEid = recomendedByEid;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()

            .IsBetween(Title.Length0IfNullOrEmpty(), 2, 128, "Title", Messages.V_IsBetween.ToFormat("Title", "2", "128"))
            .IsBetween(Url.Length0IfNullOrEmpty(), 2, 128, "Url", Messages.V_IsBetween.ToFormat("Url", "2", "128"))
            .IsBetween(RecomendedByEid.Length0IfNullOrEmpty(), 2, 128, "RecomendedByEid", Messages.V_IsBetween.ToFormat("RecomendedByEid", "2", "128"))

            .IsNotNull(Id, "Id", Messages.V_IsNotNullOrEmpty.ToFormat("Id"))
            .IsNotNull(Value, "Value", Messages.V_IsNotNullOrEmpty.ToFormat("Value"))
            .IsNotNull(Stars, "Stars", Messages.V_IsNotNullOrEmpty.ToFormat("Stars"))
            );
        }
    }
}