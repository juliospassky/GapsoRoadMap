using System;
using Flunt.Notifications;
using Flunt.Validations;
using GTSharp.Domain.Resources;
using GTSharp.Domain.Utils;

namespace GTSharp.Domain.Commands.Input.CreateCommand
{
    public class UpdateRecomendationCommand : Notifiable, ICommand
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public Decimal? Value { get; set; }
        public string RecomendedByEid { get; set; }
        public bool IsApproved { get; private set; }

        public UpdateRecomendationCommand(int id, string title, string url, decimal? value, string recomendedByEid, bool isApproved)
        {
            Id = id;
            Title = title;
            Url = url;
            Value = value;
            RecomendedByEid = recomendedByEid;
            IsApproved = isApproved;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()

            .IsBetween(Title.Length0IfNullOrEmpty(), 2, 128, "Title", Messages.V_IsBetween.ToFormat("Title", "2", "128"))
            .IsBetween(Url.Length0IfNullOrEmpty(), 2, 1024, "Url", Messages.V_IsBetween.ToFormat("Url", "2", "1024"))
            .IsBetween(RecomendedByEid.Length0IfNullOrEmpty(), 2, 128, "RecomendedByEid", Messages.V_IsBetween.ToFormat("RecomendedByEid", "2", "128"))

            .IsNotNull(Id, "Id", Messages.V_IsNotNullOrEmpty.ToFormat("Id"))
            .IsNotNull(Value, "Value", Messages.V_IsNotNullOrEmpty.ToFormat("Value"))
            .IsNotNull(IsApproved, "IsApproved", Messages.V_IsNotNullOrEmpty.ToFormat("IsApproved"))
            );
        }
    }
}