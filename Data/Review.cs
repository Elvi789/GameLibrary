using System.ComponentModel.DataAnnotations.Schema;

namespace GameLibrary.Data
{
    public class Review : BaseEntity
    {
        public float ReviewValue { get; set; }

        // review do te kete nje lidhje me Game. Lidhja do te jete e tipit 1 me n
        // 1 game ka shume review nga usera te ndryshem. 

        

        [ForeignKey("GameId")]
        public int? GameId { get; set; }
        public virtual Game? Game { get; set; }
    }
}
