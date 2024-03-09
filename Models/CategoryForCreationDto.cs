using GameLibrary.Data;

namespace GameLibrary.Models
{
    public class CategoryForCreationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<int>? GameIds { get; set; }
        public IEnumerable<Game>? Games { get; set; }
    }
}
