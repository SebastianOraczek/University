using MN_SO_APS_PROJECT.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MN_SO_APS_PROJECT.Models
{
    public class CommentModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
    }
}
