using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nocturne.Common.Models
{
    public class DiscountType
    {
        public int Id { get; set; }

        [ForeignKey("Name")]
        [Display(Name = "DiscountTypeName", ResourceType = typeof(Resources.Resources))]
        public int NameId { get; set; }
        public MultiLangString Name { get; set; }


        [Display(Name = "IsActive", ResourceType = typeof(Resources.Resources))]
        public bool IsActive { get; set; }   

    }
}
