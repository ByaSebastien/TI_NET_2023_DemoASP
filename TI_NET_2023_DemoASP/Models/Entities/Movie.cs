namespace TI_NET_2023_DemoASP.Models.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public Movie() { }
        public Movie(string title, string? description, string? imageUrl)
        {
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
        }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            return obj is Movie m && this == m;
        }

        public static bool operator ==(Movie movie1,Movie movie2)
        {
            return movie1.Id == movie2.Id &&
                   movie1.Title == movie2.Title &&
                   movie1.Description == movie2.Description;
        }

        public static bool operator !=(Movie movie1,Movie movie2)
        {
            return !(movie1 == movie2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title, Description);
        }

        public override string ToString()
        {
            return $"ID : {Id}, Title : {Title}, Description : {Description}";
        }
    }
}
