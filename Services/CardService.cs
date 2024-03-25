using GameLibrary.Data;
using GameLibrary.Repository;
using NuGet.Protocol;

namespace GameLibrary.Services
{
    public class CardService : ICardServices
    {
        private readonly CardRepository _cardRepository;
        public CardService(CardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public async Task<Card> GetCardByIdAsync(int id)
        {
            return await _cardRepository.GetById(id);
        }

        public async Task<List<Card>> GetAllCardsAsync()
        {
            return await _cardRepository.GetAll();
        }

        public async Task CreateCardAsync(Card card)
        {
            await _cardRepository.Add(card);
        }

        public async Task EditCardAsync(Card card)
        {
            await _cardRepository.Update(card);

        }

        public async Task DeleteCardAsync(Card card)
        {
            await _cardRepository.Delete(card);
        }
    }
}
