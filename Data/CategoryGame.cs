using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameLibrary.Data
{
    public class CategoryGame
    {
        [Key]
        public int Id {  get; set; }


        // lidhja n me n e game me category do te krijohet nepermjet injuction table CategoryGame.
        [ForeignKey("GameId")]
        public int? GameId {  get; set; }
        public virtual Game? Game { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId {  get; set; }
        public virtual Category? Category { get; set; }
    }
}
