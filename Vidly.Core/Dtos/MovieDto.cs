namespace Vidly.Core.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int InStock { get; set; }
        public GenreDto Genre { get; set; }
    }
}
