using System.ComponentModel.DataAnnotations;

namespace GameLibrary.Data
{
    public class Category : BaseEntity
    {
        [Key]
        public int Id {  get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<CategoryGame>? CategoryGames {  get; set; }
    }
}
