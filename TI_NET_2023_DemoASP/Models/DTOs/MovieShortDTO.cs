using TI_NET_2023_DemoASP.Models.Entities;

namespace TI_NET_2023_DemoASP.Models.DTOs
{
    public class MovieShortDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public MovieShortDTO() { }
        public MovieShortDTO(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
