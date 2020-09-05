using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTSharp.Domain.Entities
{
    public class Comment : Entity
    {
        [Required]
        [MinLength(2)]
        [MaxLength(1024)]
        public string Title { get; private set; }

        [Required]
        [MinLength(2)]
        [MaxLength(128)]
        public string Eid { get; private set; }

        [ForeignKey("Course")]
        public int? CourseId { get; private set; }

        public DateTime? CreateAt { get; private set; }

        public DateTime? UpdateAt { get; private set; }

        public Comment() { }

        public Comment(string title, string eid, int? courseId)
        {
            Title = title;
            Eid = eid;
            CourseId = courseId;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
    }
}