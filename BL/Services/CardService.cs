using System;
using System.Linq;
using Nocturne.Common.Interfaces;
using Nocturne.Common.Models;

namespace Nocturne.BL.Services
{
    public class CardService : ICardService
    {
        public int? GetUserIdAssotiatedWithCard(int cardId)
        {
            using (var dc = new NocturneContext())
            {
                return dc.Cards.Where(q => q.Id == cardId).Select(q => q.UserId).Single();
            }
        }

        public int? GetClientIdAssotiatedWithCard(int cardId)
        {
            using (var dc = new NocturneContext())
            {
                return dc.Cards.Where(q => q.Id == cardId).Select(q => q.ClientId).Single();
            }
        }

        public ValidationResult<bool> AssotiateCardWithUser(int userId, int cardId)
        {
            var validationResult = new ValidationResult<bool>();
            using (var dc = new NocturneContext())
            {
                var card = dc.Cards.Where(q => q.Id == cardId).Single();
                validationResult.ValidateProperty((msg) => { return card.UserId.HasValue ? new ValidationErrorMessage(msg) : null; },
                   "Card assotiated with other user",
                   "CardId");
                if (!validationResult.HasValidationMessageType<ValidationErrorMessage>()) { return validationResult; }
                card.UserId = userId;
                dc.SaveChanges();
            }
            validationResult.Result = true;
            return validationResult;
        }

        public ValidationResult<bool> AssotiateCardWithClient(int clientId, int cardId)
        {
            var validationResult = new ValidationResult<bool>();
            using (var dc = new NocturneContext())
            {
                var card = dc.Cards.Where(q => q.Id == cardId).Single();
                validationResult.ValidateProperty((msg) => { return card.ClientId.HasValue ? new ValidationErrorMessage(msg) : null; },
               "Card assotiated with another client",
               "CardId");
                if (!validationResult.HasValidationMessageType<ValidationErrorMessage>()) { return validationResult; }
                card.ClientId = cardId;
                dc.SaveChanges();
            }
            validationResult.Result = true;
            return validationResult;
        }

        public Card[] Find(Func<Card, bool> predicate)
        {
            using (var dc = new NocturneContext())
            {
                return dc.Cards.Where(predicate).ToArray();
            }
        }

        public Card GetCard(int id)
        {
            using (var dc = new NocturneContext())
            {
                return dc.Cards.Where(q => q.Id == id).SingleOrDefault();
            }
        }

        public ValidationResult<int> SaveCard(Card card)
        {
            var validationResult = ValidateCard(card);
            validationResult.ValidateProperty((msg) => { return card.Id != 0 ? new ValidationErrorMessage(msg) : null; }, "Can't change exist card");

            var existCard = Find(s => s.DisplayName == card.DisplayName && s.CardType == card.CardType).SingleOrDefault();
            validationResult.ValidateProperty((msg) => { return existCard != null ? new ValidationErrorMessage(msg) : null; }, $"Exist card with same UID");
            if (validationResult.HasValidationMessageType<ValidationErrorMessage>()) { return validationResult; }

            using (var dc = new NocturneContext())
            {
                var cardDb = new Card
                {
                    Uid = card.Uid,
                    CardType = (int)card.CardType,
                    Firstname = card.Firstname,
                    Lastname = card.Lastname,
                    RegCard = card.RegCard,
                };
                dc.Cards.Add(cardDb);
                dc.SaveChanges();
                card.Id = cardDb.Id;
            }
            validationResult.Result = card.Id;
            return validationResult;
        }

        private ValidationResult<int> ValidateCard(Card card)
        {
            const string emptyErrorTemplate = "{0} can not be blank.";
            var result = new ValidationResult<int>();

            result.ValidateProperty((msg) => { return string.IsNullOrEmpty(card.DisplayName) || card.DisplayName == "0" ? new ValidationErrorMessage(msg) : null; },
                string.Format(emptyErrorTemplate, "Display name"),
                nameof(card.DisplayName));

            return result;
        }
    }
}
