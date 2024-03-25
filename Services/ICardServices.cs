using GameLibrary.Data;

namespace GameLibrary.Services
{
    public interface ICardServices
    {
        Task<Card> GetCardByIdAsync(int id);
        Task<List<Card>> GetAllCardsAsync();
        Task CreateCardAsync(Card card);
        Task EditCardAsync(Card card);
        Task DeleteCardAsync(Card card);
    }
}