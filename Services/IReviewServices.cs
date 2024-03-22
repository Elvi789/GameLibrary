using GameLibrary.Data;

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
    }
}