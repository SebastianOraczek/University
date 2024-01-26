using System.ComponentModel.DataAnnotations;

namespace MN_SO_APS_PROJECT.Models
{
    public class CountryModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CountryName { get; set; }
    }
}
