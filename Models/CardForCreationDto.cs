namespace GameLibrary.Models
{
    public class CardForCreationDto
    {
        public string CardHolder { get; set; }
        public long CardNumber { get; set; }
        public int Cvv { get; set; }
        public DateTime ExpireDate { get; set; }
        public double Balance { get; set; }
    }
}
