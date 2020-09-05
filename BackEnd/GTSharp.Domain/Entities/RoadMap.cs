using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTSharp.Domain.Entities
{
    public class RoadMap : Entity
    {
        [Required]
        [MinLength(2)]
        [MaxLength(128)]
        public string Title { get; private set; }
        
        public List<Node> Nodes { get; set; }

        public DateTime? CreateAt { get; private set; }

        public DateTime? UpdateAt { get; private set; }

        public RoadMap(){}
        
        public RoadMap(string title)
        {
            Title = title;
            Nodes = new List<Node>();
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
    }
}