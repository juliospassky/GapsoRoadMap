using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTSharp.Domain.Entities
{
    public class Node : Entity
    {
        [Required]
        [MinLength(2)]
        [MaxLength(128)]
        public string Title { get; private set; }

        public List<Subtitle> Subtitles { get; set; }

        public List<Course> Courses { get; set; }

        public List<Recomendation> Recomendations { get; set; }

        [ForeignKey("RoadMap")]
        public int RoadMapId { get; private set; }

        public DateTime? CreateAt { get; private set; }

        public DateTime? UpdateAt { get; private set; }

        public Node() { }

        public Node(string title, int roadMapId)
        {
            Title = title;
            Subtitles = new List<Subtitle>();
            Courses = new List<Course>();
            Recomendations = new List<Recomendation>();
            RoadMapId = roadMapId;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
    }
}