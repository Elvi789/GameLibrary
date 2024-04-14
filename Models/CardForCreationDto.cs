﻿namespace GameLibrary.Models
{
    public class CardForCreationDto
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public int CVV { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public decimal Amount { get; set; }
        public string CardHolder { get; set; }
    }
}
