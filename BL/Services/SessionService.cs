using Nocturne.Common.Interfaces;
using Nocturne.Common.Models;
using System;
using System.Linq;

namespace Nocturne.BL.Services
{
    public class SessionService : ISessionService
    {
        /// <summary>
        /// Aktiivsed sessioonid: SessionService.Find(s => s.To == null)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Session[] Find(Func<Session, bool> predicate)
        {
            using (var dc = new NocturneContext())
            {
                return dc.Sessions.Where(predicate).ToArray();
            }
        }

        public Session GetSession(int id)
        {
            using (var dc = new NocturneContext())
            {
                return dc.Sessions.Where(q => q.Id == id).SingleOrDefault();
            }
        }

        public ValidationResult<int> StartSession(Session session)
        {
            var validationResult = ValidateSession(session);
            validationResult.ValidateProperty((msg) => { return session.Id != 0 ? new ValidationErrorMessage(msg) : null; }, "Can't start exist session");

            var existSesion = Find(s => s.CardId == session.CardId && !s.To.HasValue).SingleOrDefault();
            validationResult.ValidateProperty((msg) => { return existSesion != null ? new ValidationErrorMessage(msg) : null; }, $"Session already started at {existSesion?.From: dd.MM.yyyy HH:mm}", nameof(session.CardId));
            if (validationResult.HasValidationMessageType<ValidationErrorMessage>()) { return validationResult; }

            using (var dc = new NocturneContext())
            {
                var sessionDb = new Session
                {
                    CardId = session.CardId,
                    ClientId = session.ClientId,
                    From = session.From,
                    RegisteredById = session.RegisteredById
                };
                dc.Sessions.Add(sessionDb);
                dc.SaveChanges();
                session.Id = sessionDb.Id;
                validationResult.Result = sessionDb.Id;
            }
            return validationResult;
        }

        public ValidationResult<int> StopSession(Session session)
        {
            var validationResult = ValidateSession(session);
            validationResult.ValidateProperty((msg) => { return session.Id == 0 ? new ValidationErrorMessage(msg) : null; }, "Can't stop a session that doesn't exist");
            if (validationResult.HasValidationMessageType<ValidationErrorMessage>()) { return validationResult; }

            using (var dc = new NocturneContext())
            {
                var sessionDb = dc.Sessions.Where(q => q.Id == session.Id).Single();
                sessionDb.To = session.To;
                dc.SaveChanges();
            }
            validationResult.Result = session.Id;
            return validationResult;
        }

        public UsedProduct[] Find(Func<UsedProduct, bool> predicate)
        {
            using (var dc = new NocturneContext())
            {
                return dc.UsedProducts.Where(predicate).ToArray();
            }
        }

        public UsedProduct GetUsedProduct(int usedProductId)
        {
            using (var dc = new NocturneContext())
            {
                return dc.UsedProducts.Where(q => q.Id == usedProductId).SingleOrDefault();
            }
        }

        public ValidationResult<int> SaveUsedProduct(UsedProduct usedProduct)
        {
            var validationResult = ValidateUsedProduct(usedProduct);
            if (validationResult.HasValidationMessageType<ValidationErrorMessage>()) { return validationResult; }

            using (var dc = new NocturneContext())
            {
                UsedProduct usedProductDb;
                if (usedProduct.Id > 0)
                {
                    usedProductDb = dc.UsedProducts.Single(q => q.Id == usedProduct.Id);
                }
                else
                {
                    usedProductDb = new UsedProduct();
                    dc.UsedProducts.Add(usedProductDb);
                }

                usedProductDb.Amount = usedProduct.Amount;
                usedProductDb.Date = usedProduct.Date;
                usedProductDb.ProductId = usedProduct.ProductId;
                usedProductDb.RegisteredById = usedProduct.RegisteredById;
                usedProductDb.SessionId = usedProduct.SessionId;

                dc.SaveChanges();
                usedProduct.Id = usedProductDb.Id;
                validationResult.Result = usedProduct.Id;
            }
            return validationResult;
        }

        private ValidationResult<int> ValidateUsedProduct(UsedProduct usedProduct)
        {
            const string emptyErrorTemplate = "{0} can not be blank.";
            const string atLeastOneErrorTemplate = "{0} must be >= 1.";
            var result = new ValidationResult<int>();

            result.ValidateProperty((msg) => { return usedProduct.ProductId <= 0 ? new ValidationErrorMessage(msg) : null; },
                string.Format(emptyErrorTemplate, "Product"),
                nameof(usedProduct.ProductId));

            result.ValidateProperty((msg) => { return usedProduct.Amount < decimal.One ? new ValidationErrorMessage(msg) : null; },
               string.Format(atLeastOneErrorTemplate, "Amount"),
               nameof(usedProduct.Amount));

            result.ValidateProperty((msg) => { return usedProduct.SessionId <= 0 ? new ValidationErrorMessage(msg) : null; },
               string.Format(emptyErrorTemplate, "Session"),
               nameof(usedProduct.SessionId));

            return result;
        }

        private ValidationResult<int> ValidateSession(Session session)
        {
            const string emptyErrorTemplate = "{0} can not be blank.";
            var result = new ValidationResult<int>();

            result.ValidateProperty((msg) => { return session.CardId <= 0 ? new ValidationErrorMessage(msg) : null; },
                string.Format(emptyErrorTemplate, "Card"),
                nameof(session.CardId));

            return result;
        }
    }
}
