using System.ComponentModel.DataAnnotations;

namespace GameLibrary.Data
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
