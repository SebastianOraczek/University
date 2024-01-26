using System.ComponentModel.DataAnnotations;

namespace MN_SO_APS_PROJECT.Models
{
    public class CityModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CityName { get; set; }
    }
}
