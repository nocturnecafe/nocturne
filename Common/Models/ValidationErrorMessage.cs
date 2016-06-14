using Nocturne.Common.Interfaces;

namespace Nocturne.Common.Models
{
    public class ValidationErrorMessage : IValidationMessage
    {
        public string Message { get; set; }

        public ValidationErrorMessage(string message)
        {
            Message = message;
        }

        public ValidationErrorMessage()
        {
        }
    }
}
