using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTSharp.Domain.Entities
{
    public class Recomendation : Entity
    {
        [Required]
        [MinLength(2)]
        [MaxLength(128)]
        public string Title { get; private set; }

        [Required]
        [MinLength(2)]
        [MaxLength(1024)]
        public string Url { get; private set; }

        [Required]
        public Decimal? Value { get; private set; }

        [Required]
        [MinLength(2)]
        [MaxLength(128)]
        public string RecomendedByEid { get; private set; }

        public bool IsApproved { get; private set; }

        [ForeignKey("Node")]
        public int NodeId { get; private set; }

        public DateTime? CreateAt { get; private set; }

        public DateTime? UpdateAt { get; private set; }

        public Recomendation() { }

        public Recomendation(string title, string url, decimal? value, string recomendedByEid, int nodeId)
        {
            Title = title;
            Url = url;
            Value = value;
            RecomendedByEid = recomendedByEid;
            IsApproved = false;
            NodeId = nodeId;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
    }
}