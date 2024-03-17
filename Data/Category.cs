using System.ComponentModel.DataAnnotations;

namespace GameLibrary.Data
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<CategoryGame>? CategoryGames {  get; set; }
    }
}
