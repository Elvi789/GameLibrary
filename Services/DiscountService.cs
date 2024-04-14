using GameLibrary.Data;
using GameLibrary.Repository;
using GameLibrary.Repository.Pagination;

namespace GameLibrary.Services
{
    public class DiscountService : IDiscountServices
    {
        private readonly DiscountRepository _repository;
        public DiscountService(DiscountRepository repository)
        {
            _repository = repository;
        }
        public async Task<PaginatedList<Discount>> GetPaginatedDiscounts(int page = 1, int pageSize = 10)
        {
            return await _repository.GetPaginatedDiscount(page, pageSize);
        }

        public async Task<List<Discount>> GetAllDiscountsAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<Discount> GetDiscountByIdAsync(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task DeleteDiscountAsync(Discount discount)
        {
            await _repository.Delete(discount);
        }

        public async Task EditDiscountAsync(Discount discount)
        {
            await _repository.Update(discount);
        }

        public async Task CreateDiscountAsync(Discount discount)
        {
            await _repository.Add(discount);
        }

        public async Task<List<Discount>> GetAllDiscountsGameIncludedAsync()
        {
            return await _repository.GetAllDiscountsGameIncludedAsync();
        }
    }
}
