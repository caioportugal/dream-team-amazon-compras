using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazon.Purchases.Model
{
    public class PurchaseProduct
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PurchaseId")]
        [Required]
        public int PurchaseId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public decimal ProductValue { get; set; }

        public virtual Purchase Purchase { get; set; }
    }
}