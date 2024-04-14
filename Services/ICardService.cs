using GameLibrary.Data;
using GameLibrary.Repository.Pagination;

namespace GameLibrary.Services
{
    public interface ICardService
    {
        Task<IEnumerable<Card>> GetAllCards();
        Task<Card> GetCardById(int id);
        Task CreateCard(Card card);
        Task EditCard(Card card);
        Task DeleteCard(Card card);
        Task<PaginatedList<Card>> GetPaginatedCard(int page = 1, int pageSize = 10);
    }
}
