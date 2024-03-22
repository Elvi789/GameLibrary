using GameLibrary.Data;

namespace GameLibrary.Models
{
    public class ReviewForCreationDto
    {
        public float ReviewValue { get; set; }

        // review do te kete nje lidhje me Game. Lidhja do te jete e tipit 1 me n
        // 1 game ka shume review nga usera te ndryshem. 

        public int GameId { get; set; }
        public ICollection<Game>? Games { get; set; } // keto vihen ne dto per tu shfaqeur ne view qe useri te mund te zgjedhe.
    }
}
