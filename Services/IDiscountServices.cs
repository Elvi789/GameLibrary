using GameLibrary.Data;

namespace GameLibrary.Services
{
    public interface IDiscountServices
    {
        Task<List<Discount>> GetAllDiscountsAsync();
        Task<Discount> GetDiscountByIdAsync(int id);
        Task DeleteDiscountAsync(Discount discount);
        Task EditDiscountAsync(Discount discount);
        Task CreateDiscountAsync(Discount discount);
        Task<List<Discount>> GetAllDiscountsGameIncludedAsync();

    }
}