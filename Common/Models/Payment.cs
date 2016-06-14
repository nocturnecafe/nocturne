
using System;

namespace Nocturne.Common.Models
{
    public class Payment
    {
        public int Amount { get; set; }
        public int Id { get; set; }
        public int PaymentTypeId { get; set; }
        public int SessionId { get; set; }
        public DateTime Time { get; set; }
    }
}
