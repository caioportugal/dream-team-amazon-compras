using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Amazon.Purchases.Model
{
    public class Purchase
    {
        public Purchase()
        {
            PurchaseProduct = new HashSet<PurchaseProduct>();
        }
        [Key]
        [Required]
        public int Id { get; set; }

        public virtual ICollection<PurchaseProduct> PurchaseProduct { get; set; }
    }
}