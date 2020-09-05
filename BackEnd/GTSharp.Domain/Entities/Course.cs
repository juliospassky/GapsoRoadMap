using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTSharp.Domain.Entities
{
    public class Course : Entity
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
        public Decimal Value { get; private set; }

        [Required]
        public Decimal Stars { get; private set; }

        [Required]
        [MinLength(2)]
        [MaxLength(128)]
        public string RecomendedByEid { get; private set; }

        public List<Comment> Comments { get; set; }

        [ForeignKey("Node")]
        public int NodeId { get; private set; }

        public DateTime? CreateAt { get; private set; }

        public DateTime? UpdateAt { get; private set; }

        public Course() { }

        public Course(string title, string url, decimal value, decimal stars, string recomendedByEid, int nodeId)
        {
            Title = title;
            Url = url;
            Value = value;
            Stars = stars;
            RecomendedByEid = recomendedByEid;
            NodeId = nodeId;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
    }
}