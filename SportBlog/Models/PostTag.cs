using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportBlog.Models
{
    public class PostTag
    {
        public int Id { get; set; }
        [Required]
        public int PostId { get; set; }
        [Required]
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
       
        public int TagId { get; set; }
        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}
