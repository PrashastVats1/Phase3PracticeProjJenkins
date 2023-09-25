using System.ComponentModel.DataAnnotations;

namespace Phase3JenkinsProj.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pizza Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        public float Price { get; set; }
    }
}
