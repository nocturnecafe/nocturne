using System;
using Nocturne.Common.Models;

namespace Nocturne.Common.Interfaces
{
    /// <summary>
    /// Service to manage active client sessions.
    /// </summary>
    public interface ISessionService
    {
        UsedProduct[] Find(Func<UsedProduct, bool> predicate);
        Session[] Find(Func<Session, bool> predicate);
        Session GetSession(int id);
        UsedProduct GetUsedProduct(int usedProductId);
        ValidationResult<int> StartSession(Session session);
        ValidationResult<int> StopSession(Session session);
        ValidationResult<int> SaveUsedProduct(UsedProduct usedProduct);
    }
}