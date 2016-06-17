using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nocturne.Common.Models
{
    public class Product
    {
        public int Id { get; set; }

        [ForeignKey("Name")]
        [Display(Name = "ProductName", ResourceType = typeof(Resources.Resources))]
        public int NameId { get; set; }
        public MultiLangString Name { get; set; }

        [ForeignKey("Description")]
        [Display(Name = "ProductDescription", ResourceType = typeof(Resources.Resources))]
        public int DescriptionId { get; set; }
        public MultiLangString Description { get; set; }

        public byte[] DisplayImage { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "is active")]
        public bool IsActive { get; set; }
        
    }
}
