using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nocturne.Common.Models
{
    public class DiscountType
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Discount Type")]
        [MaxLength(50)]
        public string Name { get; set; }

        //[ForeignKey("Name")]
        //[Display(Name = "Discount Type"/*, ResourceType = typeof(Resources.Domain)*/)]
        //public int NameId { get; set; }
        //public virtual MultiLangString Name { get; set; }


        [Display(Name = "is active")]
        public bool IsActive { get; set; }   

    }
}
