using GameLibrary.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameLibrary.Models
{
    public class DiscountForCreationDto
    {
        public string Code { get; set; }

        public int Usages { get; set; }

        public double Amount { get; set; }
        public double PercentageAmount { get; set; }
        public bool IsPercentage { get; set; }
        public bool IsFixedAmount { get; set; }

       public int? GameId { get; set; }
        public ICollection<Game>? Games { get; set; }
    }
}
