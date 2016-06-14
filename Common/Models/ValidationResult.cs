using Nocturne.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nocturne.Common.Models
{
    public class ValidationResult<T>
    {
        public const string GenericError = "GenericError";

        public Dictionary<string, ValidationErrorMessage[]> Messages { get; } = new Dictionary<string, ValidationErrorMessage[]>();
        public T Result { get; set; }

        public bool HasValidationMessageType<TT>(string property = null) where TT : ValidationErrorMessage
        {
            if (string.IsNullOrEmpty(property))
            {
                return Messages.Values.Any(collection => collection.Any(msg => msg is ValidationErrorMessage));
            }
            return Messages.ContainsKey(property) && Messages[property].Any(msg => msg is ValidationErrorMessage);
        }

        private void AddValidationMessage(ValidationErrorMessage message, string property)
        {
            if (!Messages.ContainsKey(property))
            {
                Messages[property] = new[] { message };
            }
            else if (!Messages[property].Any(msg => msg.Message.Equals(message.Message) || msg == message))
            {
                var messages = Messages[property].ToList();
                messages.Add(message);
                Messages[property] = messages.ToArray();
            }
        }

        private void RemoveValidationMessage(string message, string property)
        {
            if (!Messages.ContainsKey(property)) { return; }
            var messages = Messages[property].ToList();
            messages.RemoveAll(msg => msg.Message.Equals(message));
            if (messages.Count > 0)
            {
                Messages[property] = messages.ToArray();
            }
            else
            {
                Messages.Remove(property);
            }
        }

        public ValidationErrorMessage ValidateProperty(Func<string, ValidationErrorMessage> validationDelegate, string failureMessage, string propertyName = GenericError)
        {
            if (validationDelegate == null) { return null; }
            if (string.IsNullOrEmpty(failureMessage)) { return null; }
            if (string.IsNullOrEmpty(propertyName)) { return null; }

            ValidationErrorMessage result = validationDelegate(failureMessage);
            if (result != null)
            {
                AddValidationMessage(result, propertyName);
            }
            else
            {
                RemoveValidationMessage(failureMessage, propertyName);
            }
            return result;
        }
    }
}