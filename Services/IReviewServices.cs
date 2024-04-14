using GameLibrary.Data;
using GameLibrary.Repository.Pagination;

namespace GameLibrary.Services
{
    public interface IReviewServices
    {
        Task<List<Review>> GetAllReviewsAsync();
        Task<Review> GetReviewByIdAsync(int id);
        Task CreateReviewAsync(Review review);
        Task DeleteReviewAsync(Review review);
        Task EditReviewAsync(Review review);
        Task<List<Review>> GetAllReviewsWithGames();
        Task<PaginatedList<Review>> GetPaginatedReviews(int page = 1, int pageSize = 10);
    }
}