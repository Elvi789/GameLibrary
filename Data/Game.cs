﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameLibrary.Data
{
    public class Game : BaseEntity
    {
        
        
        public string Title { get; set; }
        public string Description { get; set; }
        public int RequiredAge { get; set; }
        public int Price { get; set; }

        public DateTime ReleasedDate { get; set; } = DateTime.Now;

        public string? MinimumRequirements { get; set; }
        public string? RecommendedRequirements { get; set; }
        public bool IsForSale { get; set; }


        // per te bere lidhjen n me n te category me games duhet te perdorim tabelen ndihmese dhe ketu marrim nje liste me ate tabele 
        public ICollection<CategoryGame>? CategoryGames { get; set; }

        public ICollection<Discount>? Discounts { get; set;}

        public ICollection<Review>? Reviews { get; set; }
    }
}
