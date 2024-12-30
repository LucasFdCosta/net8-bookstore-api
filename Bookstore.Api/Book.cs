using System.Text.Json.Serialization;

namespace Bookstore.Api
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BookGenre Genre { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

    public enum BookGenre
    {
        Fiction,
        Romance,
        Mystery,
        Economy,
        Politics,
        Philosophy
    }
}
