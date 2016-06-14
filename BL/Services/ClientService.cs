using Nocturne.Common.Interfaces;
using Nocturne.Common.Models;
using System;
using System.Linq;

namespace Nocturne.BL.Services
{
    public class ClientService : IClientService
    {
        public Client[] Find(Func<Client, bool> predicate)
        {
            using (var dc = new NocturneContext())
            {
                 return dc.Clients.Where(predicate).ToArray();
            }
        }

        public Client GetClient(int id)
        {
            using (var dc = new NocturneContext())
            {
                return dc.Clients.Where(q => q.Id == id).SingleOrDefault();
            }
        } 

        public ValidationResult<int> SaveClient(Client client)
        {
            var validationResult = ValidateClient(client);

            var existClient = Find(s => s.IdCode == client.IdCode && s.Id != client.Id).SingleOrDefault();
            validationResult.ValidateProperty((msg) => { return existClient != null ? new ValidationErrorMessage(msg) : null; }, "Client with this id code already registered", nameof(client.IdCode));

            if (validationResult.HasValidationMessageType<ValidationErrorMessage>()) { return validationResult; }
            using (var dc = new NocturneContext())
            {
                Client clientDb;
                if (client.Id > 0)
                {
                    clientDb = dc.Clients.Single(q => q.Id == client.Id);
                }
                else
                {
                    clientDb = new Client();
                    dc.Clients.Add(clientDb);
                }

                clientDb.Name = client.Name;
                clientDb.IdCode = client.IdCode;
                clientDb.Surname = client.Surname;

                dc.SaveChanges();
                client.Id = clientDb.Id;
                validationResult.Result = client.Id;
            }
            return validationResult;
        }

      
        private ValidationResult<int> ValidateClient(Client client)
        {
            const string emptyErrorTemplate = "{0} can not be blank.";
            var result = new ValidationResult<int>();

            result.ValidateProperty((msg) => { return string.IsNullOrEmpty(client.IdCode) ? new ValidationErrorMessage(msg) : null; },
                string.Format(emptyErrorTemplate, "IdCode"),
                nameof(client.IdCode));

            result.ValidateProperty((msg) => { return string.IsNullOrEmpty(client.Name) ? new ValidationErrorMessage(msg) : null; },
               string.Format(emptyErrorTemplate, "Name"),
               nameof(client.Name));

            result.ValidateProperty((msg) => { return string.IsNullOrEmpty(client.Surname) ? new ValidationErrorMessage(msg) : null; },
               string.Format(emptyErrorTemplate, "Surname"),
               nameof(client.Surname));

            return result;
        }
    }

}

