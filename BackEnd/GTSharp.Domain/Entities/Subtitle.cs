using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTSharp.Domain.Entities
{
    public class Subtitle : Entity
    {
        [Required]
        [MinLength(2)]
        [MaxLength(128)]
        public string Title { get; private set; }

        [ForeignKey("Node")]
        public int NodeId { get; private set; }

        public DateTime? CreateAt { get; private set; }

        public DateTime? UpdateAt { get; private set; }

        public Subtitle() { }

        public Subtitle(string title, int nodeId)
        {
            Title = title;
            NodeId = nodeId;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }

        public void UpdateSubtitle(string title)
        {
            Title = title;
            UpdateAt = DateTime.Now;
        }
    }
}