using GameLibrary.Data;
using GameLibrary.Repository.Pagination;
using System.Threading.Tasks;

namespace GameLibrary.Services
{
    public interface IDiscountServices
    {
        Task<PaginatedList<Discount>> GetPaginatedDiscounts(int page = 1, int pageSize = 10);
        Task<List<Discount>> GetAllDiscountsAsync();
        Task<Discount> GetDiscountByIdAsync(int id);
        Task DeleteDiscountAsync(Discount discount);
        Task EditDiscountAsync(Discount discount);
        Task CreateDiscountAsync(Discount discount);
        Task<List<Discount>> GetAllDiscountsGameIncludedAsync();

    }
}