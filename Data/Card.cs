namespace GameLibrary.Data
{
    public class Card : BaseEntity
    {
        public string CardHolder { get; set; }
        public long CardNumber { get; set; }
        public int Cvv {  get; set; }
        public DateTime ExpireDate { get; set; } 
        public double Balance { get; set; }

        public string FormattedExpireDate => ExpireDate.ToString("MM/yy");

    }
}
