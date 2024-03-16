using NuGet.Protocol;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameLibrary.Data
{
    public class Discount : BaseEntity
    {
        public string Code { get; set; }   

        public int Usages { get; set; }

        public double Amount  { get; set; }
        public double PercentageAmount { get; set; }
        public bool IsPercentage { get; set; }
        public bool IsFixedAmount { get; set; }

        [ForeignKey("GameId")]
        public int? GameId { get; set; }
        public virtual Game? Game { get; set; }
    }
}
