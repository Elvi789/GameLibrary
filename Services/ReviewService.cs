using GameLibrary.Data;
using GameLibrary.Repository;
using GameLibrary.Repository.Pagination;

namespace GameLibrary.Services
{
    public class ReviewService : IReviewServices
    {
        private readonly ReviewRepository _reviewRepository;
        public ReviewService(ReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<PaginatedList<Review>> GetPaginatedReviews(int page = 1, int pageSize = 10)
        {
            return await _reviewRepository.GetPaginatedReview(page, pageSize);
        }
        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await _reviewRepository.GetAll();
        }
        public async Task<Review> GetReviewByIdAsync(int id)
        {
            return await _reviewRepository.GetById(id);
        }
        public async Task CreateReviewAsync(Review review)
        {
            await _reviewRepository.Add(review);
        }
        public async Task DeleteReviewAsync(Review review)
        {
            await _reviewRepository.Delete(review);
        }
        public async Task EditReviewAsync(Review review)
        {
            await _reviewRepository.Update(review);
        }

        public async Task<List<Review>> GetAllReviewsWithGames()
        {
            return await _reviewRepository.GetAllReviewsGameIncludedAsync();
        }
    }
}
