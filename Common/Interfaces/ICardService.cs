using Nocturne.Common.Models;
using System;

namespace Nocturne.Common.Interfaces
{
    /// <summary>
    /// Service to manage card and user/client relationships.
    /// </summary>
    public interface ICardService
    {
        Card[] Find(Func<Card, bool> predicate);
        Card GetCard(int id);
        ValidationResult<int> SaveCard(Card card);

        ValidationResult<bool> AssotiateCardWithUser(int userId, int cardId);
        int? GetUserIdAssotiatedWithCard(int cardId);

        ValidationResult<bool> AssotiateCardWithClient(int customerId, int cardId);
        int? GetClientIdAssotiatedWithCard(int cardId);
    }
}