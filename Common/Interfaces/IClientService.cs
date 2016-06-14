using Nocturne.Common.Models;
using System;

namespace Nocturne.Common.Interfaces
{
    /// <summary>
    /// Service interface to manage active clients.
    /// </summary>
    public interface IClientService
    {
        Client[] Find(Func<Client, bool> predicate);
        Client GetClient(int id);
        ValidationResult<int> SaveClient(Client customer);
    }
}

