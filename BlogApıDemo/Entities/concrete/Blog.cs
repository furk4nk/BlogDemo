using BlogApıDemo.Entities.Abstract;
using System;

namespace BlogApıDemo.Entities.concrete
{
    public class Blog : BaseEntity
    {
        public string BlogName { get; set; }
        public string BlogDescription { get; set; }
        public string BlogType { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
    }
}
