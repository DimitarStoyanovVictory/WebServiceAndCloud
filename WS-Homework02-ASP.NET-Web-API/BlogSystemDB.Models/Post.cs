using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Models
{
    using System.Collections.Generic;

    public class Post
    {
        private ICollection<Tag> tags;

        public Post()
        {
            tags = new HashSet<Tag>();
        }

        [Required]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return tags; }
            set { tags = value; }
        }
    }
}
