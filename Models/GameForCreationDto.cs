using GameLibrary.Data;

namespace GameLibrary.Models
{
    public class GameForCreationDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int RequiredAge { get; set; }
        public int Price { get; set; }

        public DateTime ReleasedDate { get; set; } = DateTime.Now;

        public string? MinimumRequirements { get; set; }
        public string? RecommendedRequirements { get; set; }

        public bool IsForSale { get; set; }

        public List<int>? CategoryIds { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
        // keto behen per lidhjen n me n te game me categories
    }
}
