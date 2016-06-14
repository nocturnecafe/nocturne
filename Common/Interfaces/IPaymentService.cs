using Nocturne.Common.Models;
using System;
namespace Nocturne.Common.Interfaces
{
    /// <summary>
    /// Service to manage payments.
    /// </summary>
    public interface IPaymentService
    {
        Payment[] Find(Func<Payment, bool> predicate);
        Payment GetPayment(int id);
        ValidationResult<int> SavePayment(Payment payment);  
        PaymentType[] Find(Func<PaymentType, bool> predicate);
        PaymentType GetPaymentType(int id);
    }
}