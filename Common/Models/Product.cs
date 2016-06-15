using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nocturne.Common.Models
{
    public class Product
    {
        public int Id { get; set; }

        /*[Required]
        [Display(Name = "Product Name")]
        [MaxLength(50)]
        public string Name { get; set; }*/

        [ForeignKey("Name")]
        [Display(Name = "Product name"/*, ResourceType = typeof(Resources.Domain)*/)]
        public int NameId { get; set; }
        public MultiLangString Name { get; set; }


        /*[Required]
        [MaxLength(500)]
        public string Description { get; set; }*/

        [ForeignKey("Description")]
        [Display(Name = "Description"/*, ResourceType = typeof(Resources.Domain)*/)]
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
