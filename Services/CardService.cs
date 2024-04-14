using GameLibrary.Data;
using GameLibrary.Repository;
using GameLibrary.Repository.Pagination;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace GameLibrary.Services
{
    public class CardService : ICardService
    {
        private readonly CardRepository _cardRepository;
        public CardService(CardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public async Task<PaginatedList<Card>> GetPaginatedCard(int page = 1, int pageSize = 10)
        {
            return await _cardRepository.GetPaginatedCard(page, pageSize);
        }
        public async Task<IEnumerable<Card>> GetAllCards()
        {
            return await _cardRepository.GetAll();
        }
        public async Task<Card> GetCardById(int id)
        {
            return await _cardRepository.GetById(id);
        }
        public async Task CreateCard(Card card)
        {
            await _cardRepository.Add(card);
        }
        public async Task EditCard(Card card)
        {
            await _cardRepository.Update(card);
        }
        public async Task DeleteCard(Card card)
        {
            await _cardRepository.Delete(card);
        }
    }
}
