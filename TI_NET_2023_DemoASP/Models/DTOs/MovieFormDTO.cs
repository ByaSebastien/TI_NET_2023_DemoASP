using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TI_NET_2023_DemoASP.Models.DTOs
{
    public class MovieFormDTO
    {
        [Required]
        [MaxLength(50)]
        [DisplayName("Titre")]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public MovieFormDTO() { }
        public MovieFormDTO(string title, string? description)
        {
            Title = title;
            Description = description;
        }
    }
}
