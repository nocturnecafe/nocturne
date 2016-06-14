using System.ComponentModel.DataAnnotations;

namespace Nocturne.Common.Models
{
    public class Card
    {
        public const int RfidCard = 2;   
        public const int IdCard = 1;

        public int Id { get; set; }

        public int CardType { get; set; }

        [MaxLength(50)]
        public string Firstname { get; set; }

        [MaxLength(50)]
        public string Lastname { get; set; }

        [MaxLength(50)]
        public string RegCard { get; set; }

        public ulong Uid { get; set; }

        public int? ClientId { get; set; }
        public Client Client { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
        public string DisplayName
        {
            get
            {
                return RegCard ?? Uid.ToString();
            }
        }
    }
}
