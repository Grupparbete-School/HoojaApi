using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoojaApi.Models.RelationTables
{
    public class ProductType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductTypeName { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}